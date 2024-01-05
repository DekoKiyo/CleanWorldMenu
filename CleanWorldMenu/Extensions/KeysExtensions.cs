using System.Windows.Forms;
using Rage;

namespace CleanWorldMenu.Extensions;

internal static class KeysExtensions
{
    internal static bool IsKeysDown(Keys Main, Keys Modifier = Keys.None)
    => Natives.UPDATE_ONSCREEN_KEYBOARD() is not 0 && (Game.IsKeyDown(Modifier) || Modifier is Keys.None) && Game.IsKeyDown(Main);
    internal static Keys ConvertToKey(this string KeyString) => (Keys)new KeysConverter().ConvertFromString(KeyString);
}