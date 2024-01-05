using System.Windows.Forms;
using Rage;

namespace CleanWorldMenu;

internal static class Settings
{
    internal static Keys OpenMenuKey { get; set; } = Keys.F7;
    internal static Keys OpenMenuModifierKey { get; set; } = Keys.None;

    internal static InitializationFile SettingFile = LoadFile($"{EntryPoint.PLUGIN_DIRECTORY}/{EntryPoint.SETTINGS_INI_FILE}");
    private static InitializationFile LoadFile(string path)
    {
        var ini = new InitializationFile(path);
        ini.Create();
        return ini;
    }

    internal static void Initialize()
    {
        OpenMenuKey = SettingFile.Read("Keys", "OpenMenuKey", Keys.F7);
        OpenMenuModifierKey = SettingFile.Read("Keys", "OpenMenuModifierKey", Keys.None);

        LogSettings();
    }

    private static void LogSettings()
    {
        Game.Console.Print(string.Empty);
        Game.Console.Print($"======== {EntryPoint.PLUGIN_NAME} Keys Settings ========");
        Game.Console.Print($"OpenBackupMenuKey: {OpenMenuKey}");
        Game.Console.Print($"OpenBackupMenuModifierKey: {OpenMenuModifierKey}");
        Game.Console.Print($"======== {EntryPoint.PLUGIN_NAME} Keys Settings ========");
        Game.Console.Print(string.Empty);
    }
}