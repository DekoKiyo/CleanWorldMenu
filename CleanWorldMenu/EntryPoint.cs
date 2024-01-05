using CleanWorldMenu;
using Rage;
using Rage.Attributes;

[assembly: Plugin(EntryPoint.PLUGIN_NAME, Description = "Easy to use clean world plugin.", Author = EntryPoint.DEVELOPER_NAME)]

namespace CleanWorldMenu;

internal class EntryPoint
{
    internal const string PLUGIN_NAME = "Clean World Menu";
    internal const string DEVELOPER_NAME = "DekoKiyo";
    internal const string PLUGIN_VERSION = "1.0.0";
    internal const string VERSION_PREFIX = "";
    internal const string PLUGIN_VERSION_DATA = $"Version.{VERSION_PREFIX}{PLUGIN_VERSION}";
    internal const string PLUGIN_INFO = $"~b~{PLUGIN_NAME}~s~ {PLUGIN_VERSION_DATA}";
    internal const string PLUGIN_DIRECTORY = @"plugins";
    internal const string SETTINGS_INI_FILE = @"CleanWorldMenu.ini";

    public static void Main()
    {
        Settings.Initialize();
        Menu.Initialize();
        GameFiber.StartNew(Menu.Process, $"[{PLUGIN_NAME}] Menu Update Process");
    }
}