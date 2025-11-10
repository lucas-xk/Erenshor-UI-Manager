using UnityEngine;

namespace clean_hotbars
{    
    public class CleanHotbars
    {

        public void SetOption(bool option)
        {
            for (int i = 1; i <= 10; i++)
            {
                TryDisableImageWithTMP($"UI/UIElements/Canvas/HotbarPar/Hotkeys/HK{i}", option);
                TryDisableImageWithTMP($"UI/UIElements/Canvas/HotbarPar/Hotkeys/HK{i} (1)", option);
            }
        }        

        private static void TryDisableImageWithTMP(string hkPath, bool option)
        {
            var hkObj = GameObject.Find(hkPath);
            if (hkObj == null)
                return;

            foreach (Transform child in hkObj.transform)
            {
                if (child.name == "Image")
                {
                    var textTMP = child.Find("Text (TMP)");
                    if (textTMP != null)
                    {
                        child.gameObject.SetActive(option);
                    }
                }
            }
        }
    }
}