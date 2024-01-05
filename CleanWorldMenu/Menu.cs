using Rage;
using RAGENativeUI;
using RAGENativeUI.Elements;
using CleanWorldMenu.Extensions;

namespace CleanWorldMenu;

internal static class Menu
{
    internal static MenuPool Pool;
    internal static UIMenu ClearWorldMenu;
    internal static UIMenuCheckboxItem cwLivingPeds, cwDeadPeds, cwLivingVehicles, cwDeadVehicles, cwPersistentEntities, cwReloadWorld;
    internal static UIMenuItem ConfirmClearWorld;

    internal static void Initialize()
    {
        Pool = [];
        ClearWorldMenu = new(Localization.GetString("MenuTitle"), EntryPoint.PLUGIN_INFO)
        {
            MouseControlsEnabled = false,
            ControlDisablingEnabled = false,
        };
        cwLivingPeds = new(Localization.GetString("LivingPeds"), false);
        cwDeadPeds = new(Localization.GetString("DeadPeds"), false);
        cwLivingVehicles = new(Localization.GetString("LivingVehicles"), false);
        cwDeadVehicles = new(Localization.GetString("DeadVehicles"), false);
        cwPersistentEntities = new(Localization.GetString("PersistentEntities"), false);
        cwReloadWorld = new(Localization.GetString("ReloadWorld"), false);
        ConfirmClearWorld = new(Localization.GetString("Confirm"))
        {
            ForeColor = HudColor.Red.GetColor(),
            HighlightedBackColor = HudColor.Red.GetColor()
        };
        ConfirmClearWorld.Activated += (m, i) =>
        {
            CleanWorld.ClearWorld(cwLivingPeds.Checked, cwDeadPeds.Checked, cwLivingVehicles.Checked, cwDeadVehicles.Checked, cwPersistentEntities.Checked, cwReloadWorld.Checked);
            ClearWorldMenu.Close();
        };

        ClearWorldMenu.AddItems(cwLivingPeds, cwDeadPeds, cwLivingVehicles, cwDeadVehicles, cwPersistentEntities, cwReloadWorld, ConfirmClearWorld);
        Pool.Add(ClearWorldMenu);
    }

    internal static void Process()
    {
        while (true)
        {
            GameFiber.Yield();
            Pool.ProcessMenus();

            if (KeysExtensions.IsKeysDown(Settings.OpenMenuKey, Settings.OpenMenuModifierKey))
            {
                if (Pool.IsAnyMenuOpen()) Pool.CloseAllMenus();
                else if (!Pool.IsAnyMenuOpen()) ClearWorldMenu.Visible = true;
            }
        }
    }
}