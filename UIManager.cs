using BepInEx;
using BepInEx.Configuration;
using clean_hotbars;
using minimap_config_saver;
using remove_ui_borders;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace uimanager
{
    [BepInPlugin("lucasxk.erenshor.uimanager", "UI Manager", "1.3.0")]

    public class UIManager : BaseUnityPlugin
    {
        private RemoveUIBorders removeborders;
        private CleanHotbars cleanhotbars;
        private MinimapConfigSaver minimapconfig;

        private ConfigEntry<bool> disableHotkeys;

        private ConfigEntry<KeyCode> toggleEditKey;
        private ConfigEntry<KeyCode> openGroup;
        private ConfigEntry<KeyCode> openWorldMap;
        private ConfigEntry<KeyCode> openGroupPlanning;

        private ConfigEntry<bool> disableCompass;
        private ConfigEntry<bool> disableLoc;
        private ConfigEntry<bool> disableXPBar;
        private ConfigEntry<bool> disableHotbarIcon;
        private ConfigEntry<bool> disableHotbar;
        private ConfigEntry<bool> disableMenuButton;
        private ConfigEntry<bool> disableInventoryButton;
        private ConfigEntry<bool> disableSkillsButton;
        private ConfigEntry<bool> disableJournalButton;
        private ConfigEntry<bool> disableMapButton;
        private ConfigEntry<bool> disableGuildManagerButton;
        private ConfigEntry<bool> disableGamepadButton;
        private ConfigEntry<bool> disableHelpButton;
        private ConfigEntry<bool> disableGroupButton;
        private ConfigEntry<bool> disableLockUIButton;
        private ConfigEntry<bool> disableChatBoxButton;
        private ConfigEntry<bool> disableDPS;
        private ConfigEntry<bool> disableParty;
        private ConfigEntry<bool> disablePet;
        private ConfigEntry<bool> disableBuffs;
        private ConfigEntry<bool> disableCastBar;
        private ConfigEntry<bool> disableTarget;
        private ConfigEntry<bool> disableHP;
        private ConfigEntry<bool> disableMiniMap;
        private ConfigEntry<bool> disableMiniMapButtons;
        private ConfigEntry<bool> disableMiniMapZoneName;
        private ConfigEntry<bool> disableCommandsCard;

        private ConfigEntry<Vector3> posCompass;
        private ConfigEntry<Vector3> posLoc;
        private ConfigEntry<Vector3> posMenu;
        private ConfigEntry<Vector3> posInventory;
        private ConfigEntry<Vector3> posSkills;
        private ConfigEntry<Vector3> posJournal;
        private ConfigEntry<Vector3> posMap;
        private ConfigEntry<Vector3> posGuildManager;
        private ConfigEntry<Vector3> posGamepad;
        private ConfigEntry<Vector3> posHelp;
        private ConfigEntry<Vector3> posGroup;
        private ConfigEntry<Vector3> posLockUI;
        private ConfigEntry<Vector3> posChatBox;

        private ConfigEntry<Vector3> scaleCompass;
        private ConfigEntry<Vector3> scaleLoc;
        private ConfigEntry<Vector3> scaleMenu;
        private ConfigEntry<Vector3> scaleInventory;
        private ConfigEntry<Vector3> scaleSkills;
        private ConfigEntry<Vector3> scaleJournal;
        private ConfigEntry<Vector3> scaleMap;
        private ConfigEntry<Vector3> scaleGuildManager;
        private ConfigEntry<Vector3> scaleGamepad;
        private ConfigEntry<Vector3> scaleHelp;
        private ConfigEntry<Vector3> scaleGroup;
        private ConfigEntry<Vector3> scaleLockUI;
        private ConfigEntry<Vector3> scaleChatBox;

        private void Awake()
        {
            removeborders = new RemoveUIBorders();
            cleanhotbars = new CleanHotbars();
            minimapconfig = new MinimapConfigSaver(Config);

            SceneManager.sceneLoaded += OnSceneLoaded;

            disableHotkeys = Config.Bind("Bottom Center", "Hotkeys", true, "Disables/Enables the hotkeys icons");

            toggleEditKey = Config.Bind("Hotkeys", "Toggle Edit Mode", KeyCode.F9, "Key to toggle UI edit mode");
            openGroup = Config.Bind("Hotkeys", "Group Builder", KeyCode.F, "Key to open the Group Builder window");
            openWorldMap = Config.Bind("Hotkeys", "World Map", KeyCode.N, "Key to open the world map");
            openGroupPlanning = Config.Bind("Hotkeys", "Group Management", KeyCode.T, "Key to open the Group Management window");

            disableCompass = Config.Bind("Top Center", "Compass", true, "Disables/Enables the compass");
            disableLoc = Config.Bind("Top Center", "Coordinates", true, "Disables/Enables the coordinates");
            disableCastBar = Config.Bind("Top Center", "Cast Bar", true, "Disables/Enables the cast bar");
            disableTarget = Config.Bind("Top Center", "Target", true, "Disables/Enables the target window");

            disableMenuButton = Config.Bind("Top Right Menu", "Menu", true, "Disables/Enables the Menu button");
            disableInventoryButton = Config.Bind("Top Right Menu", "Inventory", true, "Disables/Enables the Inventory button");
            disableSkillsButton = Config.Bind("Top Right Menu", "Spells & Skills", true, "Disables/Enables the Spells & Skills button");
            disableJournalButton = Config.Bind("Top Right Menu", "Journal", true, "Disables/Enables the Journal button");
            disableMapButton = Config.Bind("Top Right Menu", "Map", true, "Disables/Enables the Map button");
            disableGuildManagerButton = Config.Bind("Top Right Menu", "Guild Manager", true, "Disables/Enables the Guild Manager button");
            disableGamepadButton = Config.Bind("Top Right Menu", "Gamepad", true, "Disables/Enables the Gamepad button");
            disableHelpButton = Config.Bind("Top Right Menu", "Help", true, "Disables/Enables the Help button");
            disableGroupButton = Config.Bind("Top Right Menu", "Group Builder", true, "Disables/Enables the Group Builder button");
            disableLockUIButton = Config.Bind("Top Right Menu", "Lock UI", true, "Disables/Enables the Lock UI button");
            disableChatBoxButton = Config.Bind("Top Right Menu", "Chat Box Manager", true, "Disables/Enables the Chat Box Manager button");

            disableDPS = Config.Bind("Right", "DPS Meters", true, "Disables/Enables the DPS meters");

            disableParty = Config.Bind("Left", "Party Window", true, "Disables/Enables the party window");
            disablePet = Config.Bind("Left", "Pet Window", true, "Disables/Enables the pet window");
            disableHP = Config.Bind("Left", "Player HP/Mana window", true, "Disables/Enables the player HP/Mana window");
            disableCommandsCard = Config.Bind("Left", "Group Commands Card", true, "Disables/Enables the Group Commands Card");

            disableXPBar = Config.Bind("Bottom Center", "XP Bar", true, "Disables/Enables the XP bar");
            disableHotbarIcon = Config.Bind("Bottom Center", "Second hotbar icon", true, "Disables/Enables the second hotbar icon");
            disableHotbar = Config.Bind("Bottom Center", "Hotbar", true, "Disables/Enables the hotbar");
            disableBuffs = Config.Bind("Bottom Center", "Buffs Icons", true, "Disables/Enables the Buffs icons");

            disableMiniMap = Config.Bind("Mini Map", "Mini Map", true, "Disables/Enables the mini map");
            disableMiniMapButtons = Config.Bind("Mini Map", "Mini Map Buttons", true, "Disables/Enables the mini map buttons");
            disableMiniMapZoneName = Config.Bind("Mini Map", "Mini Map Zone Name", true, "Disables/Enables the mini map zone name");

            posCompass = Config.Bind("Objects Position", "Compass", new Vector3(-307.3f, 900.1f, 0));
            posLoc = Config.Bind("Objects Position", "Coordinates", new Vector3(-306.6f, 896.5f, 0));
            posMenu = Config.Bind("Objects Position", "Menu Button", new Vector3(925.988f, 511f, 0));
            posInventory = Config.Bind("Objects Position", "Inventory Button", new Vector3(820.927f, 511f, 0));
            posSkills = Config.Bind("Objects Position", "Skills Button", new Vector3(768.627f, 511f, 0));
            posJournal = Config.Bind("Objects Position", "Journal Button", new Vector3(716.468f, 511f, 0));
            posMap = Config.Bind("Objects Position", "Map Button", new Vector3(558.05f, 511f, 0));
            posGuildManager = Config.Bind("Objects Position", "Guild Manager Button", new Vector3(873.7f, 511f, 0));
            posGamepad = Config.Bind("Objects Position", "Gamepad Button", new Vector3(609.87f, 511f, 0));
            posHelp = Config.Bind("Objects Position", "Help Button", new Vector3(662.37f, 511f, 0));
            posGroup = Config.Bind("Objects Position", "Group Builder Button", new Vector3(503.876f, 511f, 0));
            posLockUI = Config.Bind("Objects Position", "Lock UI Button", new Vector3(394.4412f, 511f, 0));
            posChatBox = Config.Bind("Objects Position", "Chat Box Manager Button", new Vector3(449.1586f, 511f, 0));

            scaleCompass = Config.Bind("Objects Scale", "Compass", new Vector3(0.5342f, 0.8209f, 1f));
            scaleLoc = Config.Bind("Objects Scale", "Coordinates", Vector3.one);
            scaleMenu = Config.Bind("Objects Scale", "Menu Button", Vector3.one);
            scaleInventory = Config.Bind("Objects Scale", "Inventory Button", Vector3.one);
            scaleSkills = Config.Bind("Objects Scale", "Skills Button", Vector3.one);
            scaleJournal = Config.Bind("Objects Scale", "Journal Button", Vector3.one);
            scaleMap = Config.Bind("Objects Scale", "Map Button", Vector3.one);
            scaleGuildManager = Config.Bind("Objects Scale", "Guild Manager Button", Vector3.one);
            scaleGamepad = Config.Bind("Objects Scale", "Gamepad Button", Vector3.one);
            scaleHelp = Config.Bind("Objects Scale", "Help Button", Vector3.one);
            scaleGroup = Config.Bind("Objects Scale", "Group Builder Button", Vector3.one);
            scaleLockUI = Config.Bind("Objects Scale", "Lock UI Button", Vector3.one);
            scaleChatBox = Config.Bind("Objects Scale", "Chat Box Manager Button", Vector3.one);

            disableHotkeys.SettingChanged += (_, __) => cleanhotbars.SetOption(disableHotkeys.Value);

            disableCompass.SettingChanged += (_, __) => UpdateCompass();
            disableLoc.SettingChanged += (_, __) => UpdateLoc();
            disableCastBar.SettingChanged += (_, __) => UpdateCastBar();
            disableTarget.SettingChanged += (_, __) => UpdateTarget();
            disableMenuButton.SettingChanged += (_, __) => UpdateMenu();
            disableInventoryButton.SettingChanged += (_, __) => UpdateInventory();
            disableSkillsButton.SettingChanged += (_, __) => UpdateSkills();
            disableJournalButton.SettingChanged += (_, __) => UpdateJournal();
            disableMapButton.SettingChanged += (_, __) => UpdateMap();
            disableGuildManagerButton.SettingChanged += (_, __) => UpdateGuildManager();
            disableGamepadButton.SettingChanged += (_, __) => UpdateGamepad();
            disableHelpButton.SettingChanged += (_, __) => UpdateHelp();
            disableGroupButton.SettingChanged += (_, __) => UpdateGroup();
            disableLockUIButton.SettingChanged += (_, __) => UpdateLockUI();
            disableChatBoxButton.SettingChanged += (_, __) => UpdateChatBox();
            disableDPS.SettingChanged += (_, __) => UpdateDPS();
            disableParty.SettingChanged += (_, __) => UpdateParty();
            disablePet.SettingChanged += (_, __) => UpdatePet();
            disableHP.SettingChanged += (_, __) => UpdateHP();
            disableCommandsCard.SettingChanged += (_, __) => UpdateCommandsCard();
            disableXPBar.SettingChanged += (_, __) => UpdateXPBar();
            disableHotbarIcon.SettingChanged += (_, __) => UpdateHotbarIcon();
            disableHotbar.SettingChanged += (_, __) => UpdateHotbar();
            disableBuffs.SettingChanged += (_, __) => UpdateBuffs();

            disableMiniMap.SettingChanged += (_, __) => UpdateMiniMap();
            disableMiniMapButtons.SettingChanged += (_, __) => UpdateMiniMapButtons();
            disableMiniMapZoneName.SettingChanged += (_, __) => UpdateMiniMapZoneName();

            posCompass.SettingChanged += (_, __) => ApplyPosition("CompassBarProLinear", posCompass.Value);
            posLoc.SettingChanged += (_, __) => ApplyPosition("Loc", posLoc.Value);
            posMenu.SettingChanged += (_, __) => ApplyPosition("MenuButton (1)", posMenu.Value);
            posInventory.SettingChanged += (_, __) => ApplyPosition("InvButton", posInventory.Value);
            posSkills.SettingChanged += (_, __) => ApplyPosition("SpellsButton", posSkills.Value);
            posJournal.SettingChanged += (_, __) => ApplyPosition("JournalButton", posJournal.Value);
            posMap.SettingChanged += (_, __) => ApplyPosition("WorldMapButton", posMap.Value);
            posGuildManager.SettingChanged += (_, __) => ApplyPosition("SettingsButton", posGuildManager.Value);
            posGamepad.SettingChanged += (_, __) => ApplyPosition("ToggleGamepad", posGamepad.Value);
            posHelp.SettingChanged += (_, __) => ApplyPosition("HelpButton", posHelp.Value);
            posGroup.SettingChanged += (_, __) => ApplyPosition("GroupBuilder", posGroup.Value);
            posLockUI.SettingChanged += (_, __) => ApplyPosition("UIToggle", posLockUI.Value);
            posChatBox.SettingChanged += (_, __) => ApplyPosition("ChatBoxMngr", posChatBox.Value);

            scaleCompass.SettingChanged += (_, __) => ApplyScale("CompassBarProLinear", scaleCompass.Value);
            scaleLoc.SettingChanged += (_, __) => ApplyScale("Loc", scaleLoc.Value);
            scaleMenu.SettingChanged += (_, __) => ApplyScale("MenuButton (1)", scaleMenu.Value);
            scaleInventory.SettingChanged += (_, __) => ApplyScale("InvButton", scaleInventory.Value);
            scaleSkills.SettingChanged += (_, __) => ApplyScale("SpellsButton", scaleSkills.Value);
            scaleJournal.SettingChanged += (_, __) => ApplyScale("JournalButton", scaleJournal.Value);
            scaleMap.SettingChanged += (_, __) => ApplyScale("WorldMapButton", scaleMap.Value);
            scaleGuildManager.SettingChanged += (_, __) => ApplyScale("SettingsButton", scaleGuildManager.Value);
            scaleGamepad.SettingChanged += (_, __) => ApplyScale("ToggleGamepad", scaleGamepad.Value);
            scaleHelp.SettingChanged += (_, __) => ApplyScale("HelpButton", scaleHelp.Value);
            scaleGroup.SettingChanged += (_, __) => ApplyScale("GroupBuilder", scaleGroup.Value);
            scaleLockUI.SettingChanged += (_, __) => ApplyScale("UIToggle", scaleLockUI.Value);
            scaleChatBox.SettingChanged += (_, __) => ApplyScale("ChatBoxMngr", scaleChatBox.Value);
        }

        private void DisableDescription()
        {
            var Obj = GameObject.Find("UI/UIElements/RadioButtonPar/Desc");
            if (Obj != null)
                Obj.SetActive(false);
        }

        private void DisableButtonsDiamond()
        {
            var Obj = GameObject.Find("UI/UIElements/RadioButtonPar/DragButtons");
            if (Obj != null)
                Obj.SetActive(false);
        }

        private void UpdateCompass()
        {
            var Obj = GameObject.Find("UI/UIElements/Canvas/CompassBarProLinear");
            if (Obj != null)
                Obj.SetActive(disableCompass.Value);
        }

        private void UpdateLoc()
        {
            var Obj = GameObject.Find("UI/UIElements/Canvas/Loc");
            if (Obj != null)
                Obj.SetActive(disableLoc.Value);
        }

        private void UpdateCastBar()
        {
            //var Obj = GameObject.Find("UI/CastBarPar");
            var Obj = FindUIObject("UI/CastBarPar");
            if (Obj != null)
                Obj.SetActive(disableCastBar.Value);
        }

        private GameObject FindUIObject(string path)
        {
            GameObject uiRoot = GameObject.Find("UI");
            if (uiRoot == null) return null;

            string relativePath = path.StartsWith("UI/") ? path.Substring(3) : path;

            Transform target = uiRoot.transform.Find(relativePath);
            return target != null ? target.gameObject : null;
        }

        private void UpdateTarget()
        {
            var Obj = GameObject.Find("UI/UIElements/TargCanv");
            if (Obj != null)
                Obj.SetActive(disableTarget.Value);
        }

        private void UpdateMenu()
        {
            var Obj = GameObject.Find("UI/UIElements/MenuButton (1)");
            if (Obj != null)
                Obj.SetActive(disableMenuButton.Value);
        }

        private void UpdateInventory()
        {
            var Obj = GameObject.Find("UI/UIElements/InvButton");
            if (Obj != null)
                Obj.SetActive(disableInventoryButton.Value);
        }

        private void UpdateSkills()
        {
            var Obj = GameObject.Find("UI/UIElements/SpellsButton");
            if (Obj != null)
                Obj.SetActive(disableSkillsButton.Value);
        }

        private void UpdateJournal()
        {
            var Obj = GameObject.Find("UI/UIElements/JournalButton");
            if (Obj != null)
                Obj.SetActive(disableJournalButton.Value);
        }

        private void UpdateMap()
        {
            var Obj = GameObject.Find("UI/UIElements/WorldMapButton");
            if (Obj != null)
                Obj.SetActive(disableMapButton.Value);
        }

        private void UpdateGuildManager()
        {
            var Obj = GameObject.Find("UI/UIElements/SettingsButton");
            if (Obj != null)
                Obj.SetActive(disableGuildManagerButton.Value);
        }

        private void UpdateGamepad()
        {
            var Obj = GameObject.Find("UI/UIElements/ToggleGamepad");
            if (Obj != null)
                Obj.SetActive(disableGamepadButton.Value);
        }

        private void UpdateHelp()
        {
            var Obj = GameObject.Find("UI/UIElements/HelpButton");
            if (Obj != null)
                Obj.SetActive(disableHelpButton.Value);
        }

        private void UpdateGroup()
        {
            var Obj = GameObject.Find("UI/UIElements/GroupBuilder");
            if (Obj != null)
                Obj.SetActive(disableGroupButton.Value);
        }

        private void UpdateLockUI()
        {
            var Obj = GameObject.Find("UI/UIElements/UIToggle");
            if (Obj != null)
                Obj.SetActive(disableLockUIButton.Value);
        }

        private void UpdateChatBox()
        {
            var Obj = GameObject.Find("UI/UIElements/ChatBoxMngr");
            if (Obj != null)
                Obj.SetActive(disableChatBoxButton.Value);
        }

        private void UpdateDPS()
        {
            var Obj = GameObject.Find("UI/UIElements/DPSMeters");
            if (Obj != null)
                Obj.SetActive(disableDPS.Value);
        }

        private void UpdateParty()
        {
            var Obj = GameObject.Find("UI/UIElements/NewGroupPar");
            if (Obj != null)
                Obj.SetActive(disableParty.Value);
        }

        private void UpdatePet()
        {
            var Obj = GameObject.Find("UI/UIElements/CharmedPar");
            if (Obj != null)
                Obj.SetActive(disablePet.Value);
        }

        private void UpdateHP()
        {
            var Obj = GameObject.Find("UI/UIElements/PlayerLifePar");
            if (Obj != null)
                Obj.SetActive(disableHP.Value);
        }

        private void UpdateCommandsCard()
        {
            var Obj = GameObject.Find("UI/UIElements/NewGroupPar/GroupCommands(1)/Pull");
            if (Obj != null)
                Obj.SetActive(disableCommandsCard.Value);

            Obj = GameObject.Find("UI/UIElements/NewGroupPar/GroupCommands(1)/Autopull");
            if (Obj != null)
                Obj.SetActive(disableCommandsCard.Value);

            Obj = GameObject.Find("UI/UIElements/NewGroupPar/GroupCommands(1)/Atk");
            if (Obj != null)
                Obj.SetActive(disableCommandsCard.Value);

            Obj = GameObject.Find("UI/UIElements/NewGroupPar/GroupCommands(1)/Asst");
            if (Obj != null)
                Obj.SetActive(disableCommandsCard.Value);

            Obj = GameObject.Find("UI/UIElements/NewGroupPar/GroupCommands(1)/Follow");
            if (Obj != null)
                Obj.SetActive(disableCommandsCard.Value);

            Obj = GameObject.Find("UI/UIElements/NewGroupPar/GroupCommands(1)/Wait");
            if (Obj != null)
                Obj.SetActive(disableCommandsCard.Value);

            Obj = GameObject.Find("UI/UIElements/NewGroupPar/GroupCommands(1)/Manage");
            if (Obj != null)
                Obj.SetActive(disableCommandsCard.Value);

            Obj = GameObject.Find("UI/UIElements/NewGroupPar/GroupCommands(1)/Flee");
            if (Obj != null)
                Obj.SetActive(disableCommandsCard.Value);

            Obj = GameObject.Find("UI/UIElements/NewGroupPar/GroupCommands(1)/Invis");
            if (Obj != null)
                Obj.SetActive(disableCommandsCard.Value);

            Obj = GameObject.Find("UI/UIElements/NewGroupPar/GroupCommands(1)/Hotkeys/Image");
            if (Obj != null)
                Obj.SetActive(disableCommandsCard.Value);

            for (int i = 1; i <= 15 ; i++)
            {
                Obj = GameObject.Find($"UI/UIElements/NewGroupPar/GroupCommands(1)/Hotkeys/Image ({i})");
                if (Obj != null)
                    Obj.SetActive(disableCommandsCard.Value);
            }
        }

        private void UpdateXPBar()
        {
            var Obj = GameObject.Find("UI/UIElements/Canvas/HotbarPar/Vitals");
            if (Obj != null)
                Obj.SetActive(disableXPBar.Value);
        }

        private void UpdateHotbarIcon()
        {
            var parentObj = GameObject.Find("UI/UIElements/Canvas/HotbarPar");

            if (parentObj != null && parentObj.transform.childCount > 7)
            {
                var targetObj = parentObj.transform.GetChild(7).gameObject;
                targetObj.SetActive(disableHotbarIcon.Value);
            }
        }

        private void UpdateHotbar()
        {
            var Obj = GameObject.Find("UI/UIElements/Canvas/HotbarPar");
            if (Obj != null)
                Obj.SetActive(disableHotbar.Value);
        }

        private void UpdateBuffs()
        {
            var Obj = GameObject.Find("UI/UIElements/Canvas/StatusPar");
            if (Obj != null)
                Obj.SetActive(disableBuffs.Value);
        }

        private void UpdateMiniMap()
        {
            var Obj = GameObject.Find("UI/MAP PAR/MapBG");
            if (Obj != null)
                Obj.SetActive(disableMiniMap.Value);
        }

        private void UpdateMiniMapButtons()
        {
            var Obj = GameObject.Find("UI/MAP PAR/MapBG/ButtonsAndText/Image (1)");
            if (Obj != null)
                Obj.SetActive(disableMiniMapButtons.Value);

            Obj = GameObject.Find("UI/MAP PAR/MapBG/ButtonsAndText/Image");
            if (Obj != null)
                Obj.SetActive(disableMiniMapButtons.Value);

            Obj = GameObject.Find("UI/MAP PAR/MapBG/ButtonsAndText/Image (2)");
            if (Obj != null)
                Obj.SetActive(disableMiniMapButtons.Value);

            Obj = GameObject.Find("UI/MAP PAR/MapBG/ButtonsAndText/WorldMap");
            if (Obj != null)
                Obj.SetActive(disableMiniMapButtons.Value);

            Obj = GameObject.Find("UI/MAP PAR/MapBG/ButtonsAndText/North");
            if (Obj != null)
                Obj.SetActive(disableMiniMapButtons.Value);
        }

        private void UpdateMiniMapZoneName()
        {
            var Obj = GameObject.Find("UI/MAP PAR/MapBG/ButtonsAndText/ZoneName");
            if (Obj != null)
                Obj.SetActive(disableMiniMapZoneName.Value);
        }

        private void ApplySavedPositions()
        {
            SetLocalPosition("UI/UIElements/Canvas/CompassBarProLinear", posCompass.Value);
            SetLocalPosition("UI/UIElements/Canvas/Loc", posLoc.Value);
            SetLocalPosition("UI/UIElements/MenuButton (1)", posMenu.Value);
            SetLocalPosition("UI/UIElements/InvButton", posInventory.Value);
            SetLocalPosition("UI/UIElements/SpellsButton", posSkills.Value);
            SetLocalPosition("UI/UIElements/JournalButton", posJournal.Value);
            SetLocalPosition("UI/UIElements/WorldMapButton", posMap.Value);
            SetLocalPosition("UI/UIElements/SettingsButton", posGuildManager.Value);
            SetLocalPosition("UI/UIElements/ToggleGamepad", posGamepad.Value);
            SetLocalPosition("UI/UIElements/HelpButton", posHelp.Value);
            SetLocalPosition("UI/UIElements/GroupBuilder", posGroup.Value);
            SetLocalPosition("UI/UIElements/UIToggle", posLockUI.Value);
            SetLocalPosition("UI/UIElements/ChatBoxMngr", posChatBox.Value);
        }

        private void SetLocalPosition(string path, Vector3 pos)
        {
            var obj = GameObject.Find(path);
            if (obj != null)
            {
                obj.transform.localPosition = pos;
            }
        }

        private void ApplyPosition(string objName, Vector3 pos)
        {
            GameObject obj;
            if (objName == "CompassBarProLinear" || objName == "Loc")
                obj = GameObject.Find($"UI/UIElements/Canvas/{objName}");
            else
                obj = GameObject.Find($"UI/UIElements/{objName}");
            if (obj != null)
                obj.transform.localPosition = pos;
        }

        private void ApplySavedScales()
        {
            SetLocalScale("UI/UIElements/Canvas/CompassBarProLinear", scaleCompass.Value);
            SetLocalScale("UI/UIElements/Canvas/Loc", scaleLoc.Value);
            SetLocalScale("UI/UIElements/MenuButton (1)", scaleMenu.Value);
            SetLocalScale("UI/UIElements/InvButton", scaleInventory.Value);
            SetLocalScale("UI/UIElements/SpellsButton", scaleSkills.Value);
            SetLocalScale("UI/UIElements/JournalButton", scaleJournal.Value);
            SetLocalScale("UI/UIElements/WorldMapButton", scaleMap.Value);
            SetLocalScale("UI/UIElements/SettingsButton", scaleGuildManager.Value);
            SetLocalScale("UI/UIElements/ToggleGamepad", scaleGamepad.Value);
            SetLocalScale("UI/UIElements/HelpButton", scaleHelp.Value);
            SetLocalScale("UI/UIElements/GroupBuilder", scaleGroup.Value);
            SetLocalScale("UI/UIElements/UIToggle", scaleLockUI.Value);
            SetLocalScale("UI/UIElements/ChatBoxMngr", scaleChatBox.Value);
        }

        private void SetLocalScale(string path, Vector3 scale)
        {
            var obj = GameObject.Find(path);
            if (obj != null) obj.transform.localScale = scale;
        }

        private void ApplyScale(string objName, Vector3 scale)
        {
            GameObject obj;
            if (objName == "CompassBarProLinear" || objName == "Loc")
                obj = GameObject.Find($"UI/UIElements/Canvas/{objName}");
            else
                obj = GameObject.Find($"UI/UIElements/{objName}");
            if (obj != null) obj.transform.localScale = scale;
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private string sceneName;

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            sceneName = scene.name;

            if (sceneName == "Menu" || sceneName == "LoadScene")
                return;

            removeborders.DisableBorders(false);

            DisableDescription();
            DisableButtonsDiamond();
            ReparentButtons();
            PlaceObjectsUnderInventory();

            cleanhotbars.SetOption(disableHotkeys.Value);

            UpdateCompass();
            UpdateLoc();
            UpdateCastBar();
            UpdateTarget();
            UpdateMenu();
            UpdateInventory();
            UpdateSkills();
            UpdateJournal();
            UpdateMap();
            UpdateGuildManager();
            UpdateGamepad();
            UpdateHelp();
            UpdateLockUI();
            UpdateChatBox();
            UpdateDPS();
            UpdateParty();
            UpdatePet();
            UpdateHP();
            UpdateCommandsCard();
            UpdateXPBar();
            UpdateHotbarIcon();
            UpdateHotbar();
            UpdateBuffs();
            UpdateMiniMap();
            UpdateMiniMapButtons();
            UpdateMiniMapZoneName();

            ApplySavedPositions();
            ApplySavedScales();

            minimapconfig.MiniMapButtonsConfig();

            EditModeToggle();
        }

        private bool editMode = false;
        private GameObject draggingObj;
        private Vector3 offset;
        
        private void ReparentButtons()
        {
            GameObject UIElementsObj = GameObject.Find("UI/UIElements");
            if (UIElementsObj == null) return;

            string[] objectsToMove = new string[]
            {
                "UI/UIElements/RadioButtonPar/MenuButton (1)",
                "UI/UIElements/RadioButtonPar/InvButton",
                "UI/UIElements/RadioButtonPar/SpellsButton",
                "UI/UIElements/RadioButtonPar/WorldMapButton",
                "UI/UIElements/RadioButtonPar/JournalButton",
                "UI/UIElements/RadioButtonPar/SettingsButton",
                "UI/UIElements/RadioButtonPar/ToggleGamepad",
                "UI/UIElements/RadioButtonPar/HelpButton",
                "UI/UIElements/RadioButtonPar/GroupBuilder",
                "UI/UIElements/RadioButtonPar/UIToggle",
                "UI/UIElements/RadioButtonPar/ChatBoxMngr"
            };            

            foreach (var path in objectsToMove)
            {
                GameObject obj = GameObject.Find(path);
                if (obj != null)
                {
                    obj.transform.SetParent(UIElementsObj.transform, false);
                }
            }
        }

        private void PlaceObjectsUnderInventory()
        {
            GameObject inventoryObj = GameObject.Find("UI/UIElements/InvPar");
            if (inventoryObj == null) return;

            string[] objectsToMove = new string[]
            {
                "UI/UIElements/MenuButton (1)",
                "UI/UIElements/InvButton",
                "UI/UIElements/SpellsButton",
                "UI/UIElements/WorldMapButton",
                "UI/UIElements/JournalButton",
                "UI/UIElements/SettingsButton",
                "UI/UIElements/ToggleGamepad",
                "UI/UIElements/HelpButton",
                "UI/UIElements/GroupBuilder",
                "UI/UIElements/UIToggle",
                "UI/UIElements/ChatBoxMngr"
            };

            int invIndex = inventoryObj.transform.GetSiblingIndex();

            foreach (var path in objectsToMove)
            {
                GameObject obj = GameObject.Find(path);
                if (obj != null)
                {
                    obj.transform.SetSiblingIndex(invIndex - 1);
                }
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(toggleEditKey.Value) && !GameData.PlayerTyping)
            {
                var vanillaToggleButtonObj = GameObject.Find("UI/UIElements/UIToggle");

                if (vanillaToggleButtonObj != null)
                {
                    var vanillaToggleButtonComp = vanillaToggleButtonObj.GetComponent<UnityEngine.UI.Button>();
                    if (vanillaToggleButtonComp != null)
                    {
                        vanillaToggleButtonComp.onClick.Invoke();
                    }
                }
            }

            if (editMode)
                HandleDragging();

            if (Input.GetKeyDown(openGroup.Value) && !GameData.PlayerTyping)
            {
                OpenGroupBuilder();
            }

            if (Input.GetKeyDown(openWorldMap.Value) && !GameData.PlayerTyping)
            {
                OpenWorldMap();
            }

            if (Input.GetKeyDown(openGroupPlanning.Value) && !GameData.PlayerTyping)
            {
                OpenGroupPlanning();
            }

            if (Input.GetKeyDown(InputManager.Map) && !GameData.PlayerTyping)
            {                
                minimapconfig.ForceApplyZoom();
            }
        }

        private void EditModeToggle()
        {
            GameObject vanillaToggleButtonObj = GameObject.Find("UI/UIElements/UIToggle");
            if (vanillaToggleButtonObj != null)
            {
                UnityEngine.UI.Button vanillaToggleButtonComp = vanillaToggleButtonObj.GetComponent<UnityEngine.UI.Button>();
                if (vanillaToggleButtonComp != null)
                {
                    vanillaToggleButtonComp.onClick.AddListener(() => {
                        editMode = !editMode;
                        SetEditMode(editMode);
                        if (removeborders != null)
                        {
                            removeborders.DisableBorders(editMode);
                        }
                    });
                }
            }
        }

        private void OpenGroupBuilder()
        {
            var Obj = GameObject.Find("UI/UIElements/GroupBuilderPar/GroupBuilder");
            if (Obj != null)
                Obj.SetActive(!Obj.activeSelf);
        }

        private void OpenWorldMap()
        {
            var Obj = GameObject.Find("UI/UIElements/Map");
            if (Obj != null)
                Obj.SetActive(!Obj.activeSelf);
        }

        private void OpenGroupPlanning()
        {
            var Obj = GameObject.Find("UI/UIElements/Group Planning");
            if (Obj != null)
                Obj.SetActive(!Obj.activeSelf);
        }

        private List<string> draggableObjectsPaths = new List<string>()
        {
            "UI/UIElements/Canvas/CompassBarProLinear",
            "UI/UIElements/Canvas/Loc",
            "UI/UIElements/MenuButton (1)",
            "UI/UIElements/InvButton",
            "UI/UIElements/SpellsButton",
            "UI/UIElements/WorldMapButton",
            "UI/UIElements/JournalButton",
            "UI/UIElements/SettingsButton",
            "UI/UIElements/ToggleGamepad",
            "UI/UIElements/HelpButton",
            "UI/UIElements/GroupBuilder",
            "UI/UIElements/UIToggle",
            "UI/UIElements/ChatBoxMngr",
        };

        private void SetEditMode(bool enable)
        {
            foreach (var path in draggableObjectsPaths)
            {
                var obj = GameObject.Find(path);
                if (obj != null)
                {
                    var canvasGroup = obj.GetComponent<CanvasGroup>();
                    if (canvasGroup == null)
                        canvasGroup = obj.AddComponent<CanvasGroup>();

                    if (path == "UI/UIElements/UIToggle")
                    {
                        //canvasGroup.alpha = 1f;
                        canvasGroup.blocksRaycasts = true;

                        var outline = obj.GetComponent<UnityEngine.UI.Outline>();
                        if (outline == null)
                            outline = obj.AddComponent<UnityEngine.UI.Outline>();

                        outline.effectColor = new Color(1f, 0.85f, 0f, 1f); // golden color (r, g, b, a)
                        outline.effectDistance = new Vector2(2f, 2f); // thickness

                        outline.enabled = enable;
                    }
                    else
                    {
                        canvasGroup.alpha = enable ? 0.5f : 1f; // 50% tranparency                    
                        canvasGroup.blocksRaycasts = !enable; // cannot click on buttons
                    }                        
                }
            }
        }

        private void HandleDragging()
        {
            Vector3 mousePos = Input.mousePosition;
            bool isControlPressed = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);

            if (Input.GetMouseButtonDown(2))
            {
                foreach (var path in draggableObjectsPaths)
                {
                    var obj = GameObject.Find(path);
                    if (obj != null)
                    {
                        RectTransform rt = obj.GetComponent<RectTransform>();
                        if (rt != null && RectTransformUtility.RectangleContainsScreenPoint(rt, mousePos))
                        {
                            draggingObj = obj;
                            offset = rt.position - mousePos;
                            break;
                        }
                    }
                }
            }

            if (draggingObj != null && Input.GetMouseButton(2))
            {
                if (isControlPressed)
                {
                    float mouseDelta = (Input.GetAxis("Mouse X") + Input.GetAxis("Mouse Y")) * 0.01f;
                    Vector3 newScale = draggingObj.transform.localScale + new Vector3(mouseDelta, mouseDelta, mouseDelta);

                    if (newScale.x < 0.1f) newScale = new Vector3(0.1f, 0.1f, 0.1f);

                    draggingObj.transform.localScale = newScale;
                }
                else
                {
                    RectTransform rt = draggingObj.GetComponent<RectTransform>();
                    if (rt != null)
                        rt.position = mousePos + offset;
                }
            }

            if (draggingObj != null && Input.GetMouseButtonUp(2))
            {
                SavePosition(draggingObj);
                SaveScale(draggingObj);
                draggingObj = null;
            }
        }

        private void SavePosition(GameObject obj)
        {
            var localPos = obj.transform.localPosition;
            switch (obj.name)
            {
                case "CompassBarProLinear": posCompass.Value = localPos; break;
                case "Loc": posLoc.Value = localPos; break;
                case "MenuButton (1)": posMenu.Value = localPos; break;
                case "InvButton": posInventory.Value = localPos; break;
                case "SpellsButton": posSkills.Value = localPos; break;
                case "JournalButton": posJournal.Value = localPos; break;
                case "WorldMapButton": posMap.Value = localPos; break;
                case "SettingsButton": posGuildManager.Value = localPos; break;
                case "ToggleGamepad": posGamepad.Value = localPos; break;
                case "HelpButton": posHelp.Value = localPos; break;
                case "GroupBuilder": posGroup.Value = localPos; break;
                case "UIToggle": posLockUI.Value = localPos; break;
                case "ChatBoxMngr": posChatBox.Value = localPos; break;
            }

            Config.Save();
        }

        private void SaveScale(GameObject obj)
        {
            var localScale = obj.transform.localScale;
            switch (obj.name)
            {
                case "CompassBarProLinear": scaleCompass.Value = localScale; break;
                case "Loc": scaleLoc.Value = localScale; break;
                case "MenuButton (1)": scaleMenu.Value = localScale; break;
                case "InvButton": scaleInventory.Value = localScale; break;
                case "SpellsButton": scaleSkills.Value = localScale; break;
                case "JournalButton": scaleJournal.Value = localScale; break;
                case "WorldMapButton": scaleMap.Value = localScale; break;
                case "SettingsButton": scaleGuildManager.Value = localScale; break;
                case "ToggleGamepad": scaleGamepad.Value = localScale; break;
                case "HelpButton": scaleHelp.Value = localScale; break;
                case "GroupBuilder": scaleGroup.Value = localScale; break;
                case "UIToggle": scaleLockUI.Value = localScale; break;
                case "ChatBoxMngr": scaleChatBox.Value = localScale; break;
            }
            Config.Save();
        }
    }
}