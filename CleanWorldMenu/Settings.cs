using System.Windows.Forms;
using CleanWorldMenu.Extensions;
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
        OpenMenuKey = SettingFile.Read("Keys", "OpenMenuKey", "F7").ConvertToKey();
        OpenMenuModifierKey = SettingFile.Read("Keys", "OpenMenuModifierKey", "None").ConvertToKey();
    }
}