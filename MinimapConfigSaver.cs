using BepInEx.Configuration;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;

namespace minimap_config_saver
{
    public class MinimapConfigSaver
    {
        private ConfigEntry<float> zoom;
        private ConfigEntry<bool> lockNorth;
        private ConfigEntry<bool> realTime;

        private Minimap minimap;

        private ConfigFile config;

        public MinimapConfigSaver(ConfigFile configFile)
        {
            config = configFile;
        }

        public void MiniMapButtonsConfig()
        {
            zoom = config.Bind("Mini Map", "Zoom", 150f, new ConfigDescription("Map zoom", new AcceptableValueRange<float>(60f, 250f)));
            lockNorth = config.Bind("Mini Map", "Lock North", false, "Lock the map to north");
            realTime = config.Bind("Mini Map", "Real-time Geometry", false, "Draw real-time geometry (can cause FPS drops)");

            zoom.SettingChanged += (_, __) =>
            {
                if (minimap != null)
                    minimap.MapCam.orthographicSize = zoom.Value;
            };

            lockNorth.SettingChanged += (_, __) =>
            {
                if (minimap != null)
                    minimap.LockNorth = lockNorth.Value;
            };

            realTime.SettingChanged += (_, __) =>
            {
                if (minimap != null)
                {
                    var drawRealField = typeof(Minimap).GetField("DrawReal", BindingFlags.Instance | BindingFlags.NonPublic);
                    drawRealField.SetValue(minimap, realTime.Value);

                    bool drawRealValue = (bool)drawRealField.GetValue(minimap);
                    if (drawRealValue)
                        minimap.MapCam.cullingMask |= 1;
                    else
                        minimap.MapCam.cullingMask &= ~1;
                }
            };

            minimap = Object.FindObjectOfType<Minimap>();
            if (minimap != null)
            {
                minimap.MapCam.orthographicSize = zoom.Value;

                minimap.LockNorth = lockNorth.Value;

                var drawRealField = typeof(Minimap).GetField("DrawReal", BindingFlags.Instance | BindingFlags.NonPublic);
                drawRealField.SetValue(minimap, realTime.Value);

                bool drawRealValue = (bool)drawRealField.GetValue(minimap);
                if (drawRealValue)
                    minimap.MapCam.cullingMask |= 1;
                else
                    minimap.MapCam.cullingMask &= ~1;

                AddButtonListeners();
            }
        }

        public void AddButtonListeners()
        {
            var zoomInBtn = GameObject.Find("UI/MAP PAR/MapBG/ButtonsAndText/Image (1)").GetComponent<Button>();
            zoomInBtn.onClick.AddListener(() =>
            {
                zoom.Value = minimap.MapCam.orthographicSize;
                config.Save();
            });

            var zoomOutBtn = GameObject.Find("UI/MAP PAR/MapBG/ButtonsAndText/Image").GetComponent<Button>();
            zoomOutBtn.onClick.AddListener(() =>
            {
                zoom.Value = minimap.MapCam.orthographicSize;
                config.Save();
            });

            var lockBtn = GameObject.Find("UI/MAP PAR/MapBG/ButtonsAndText/North").GetComponent<Button>();
            lockBtn.onClick.AddListener(() =>
            {
                lockNorth.Value = minimap.LockNorth;
                config.Save();
            });

            var realBtn = GameObject.Find("UI/MAP PAR/MapBG/ButtonsAndText/Image (2)").GetComponent<Button>();
            var drawRealField = typeof(Minimap).GetField("DrawReal", BindingFlags.Instance | BindingFlags.NonPublic);
            realBtn.onClick.AddListener(() =>
            {
                bool drawRealValue = (bool)drawRealField.GetValue(minimap);
                realTime.Value = drawRealValue;
                config.Save();
            });
        }
    }
}