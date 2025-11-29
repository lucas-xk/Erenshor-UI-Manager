# Erenshor UI Manager Mod

## This mod allows full management of the entire UI.

The features from the [Clean Hotbars](https://github.com/lucas-xk/Erenshor-Clean-Hotbars) and [Remove UI Borders](https://github.com/lucas-xk/Erenshor-Remove-UI-Borders) mods have been integrated into this one. However, those standalone versions are still available for players who prefer using them separately.

⚠️ **NOTE: Do not use this mod together with "Clean Hotbars" or "Remove UI Borders" to avoid conflicts, as their functionality is already included in this mod.**

### Features:

- **UI Edit Mode** (default key: F9, rebindable).
- Removes the black borders/lines from UI windows.
<br>These borders only appear while in UI Edit Mode to help with alignment.
- Removes all blue diamonds.
<br>They also only appear in UI Edit Mode.
- Allows dragging all UI elements.
- Allows resetting dragged elements back to the game’s default positions.
- Allows hiding any UI element or window.
- Adds hotkeys for the Group Builder and World Map buttons (default: G and N, respectively, both rebindable).
<br>In vanilla, the World Map button loses its hotkey when the minimap is enabled via the server admin panel.
- Buttons tooltip temporarily removed to avoid having to move it to another location if the player moves the buttons.
- **The vanilla minimap settings are now saved between sessions.**
  - Zoom level
  - Lock North
  - Draw real-time geometry
- Full Configuration via Configuration Manager
<br>You can now adjust the minimap settings (Zoom, Lock North, Draw real-time geometry) directly in the Configuration Manager, so you no longer need to use the vanilla minimap buttons and can hide them if you want.
- Optional: "BigMap Position" mod
<br>If you want the larger version of the minimap to appear centered on the screen, use the "BigMap Position" mod.
Download the `bigmap-position.dll` from the releases to enable this feature.

How to Install:

Requires BepInEx:<br>
https://github.com/BepInEx/BepInEx

For easier UI configuration, install BepInEx Configuration Manager:<br>
https://github.com/BepInEx/BepInEx.ConfigurationManager/releases

Download the mod from here:<br>
https://github.com/lucas-xk/Erenshor-UI-Manager/releases

Copy the compiled DLL into your BepInEx/plugins folder.

Run the game.

Press F1 (by default) to open the Configuration Manager and customize the UI.

Press F9 (by default) to enter or exit the UI Edit Mode and drag UI elements around.

To drag elements that are not draggable by default, use the middle mouse button.
All others can be dragged using their blue diamond handles, as usual.

You can reset the dragged elements back to the game’s default positions using the Configuration Manager. To reset the elements dragged by the blue diamonds, use the vanilla "Reset UI" option on the menu.

Example of UI without the top right menu buttons, the black borders and other things removed or adjusted:

<img width="1919" height="1079" alt="Screenshot 2025-11-10 150659" src="https://github.com/user-attachments/assets/bd61107b-1531-4320-a55b-5abd9a36bc82" />
<br><br>
UI Edit Mode:

<img width="1919" height="1079" alt="Screenshot 2025-11-10 150704" src="https://github.com/user-attachments/assets/489bbcae-9baa-4a96-939c-8cc352b7603f" />
<br><br>
With target selected:

<img width="1919" height="1079" alt="Screenshot 2025-11-10 150718" src="https://github.com/user-attachments/assets/efd4ff17-2d14-4014-8a54-ba9c1a3f80c6" />
