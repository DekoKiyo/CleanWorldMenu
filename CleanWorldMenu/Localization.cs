using System.Reflection;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using Rage;

namespace CleanWorldMenu;

internal static class Localization
{
    private static readonly Dictionary<string, string> Translation = [];
    private static readonly string LanguageCode = Helpers.ConvertToTwoCode(RAGENativeUI.Localization.Language);
    private const string NO_TRANSLATION = "[NO TRANSLATION]";

    internal static void Initialize()
    {
        Load();
    }

    private static void Load()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var stream = assembly.GetManifestResourceStream($"CleanWorldMenu.Resources.{LanguageCode}.json");
        var byteArray = new byte[stream.Length];
        _ = stream.Read(byteArray, 0, (int)stream.Length);
        var json = Encoding.UTF8.GetString(byteArray);

        var data = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json);

        foreach (var obj in data)
        {
            foreach (var locale in obj.Value)
            {
                Game.Console.Print($"[Localization] Loading Translation - Key: {locale.Key} Value: {locale.Value}");
                Translation[locale.Key] = locale.Value;
            }
        }
    }

    internal static string GetString(string key)
    {
        if (Translation.ContainsKey(key)) return Translation[key];
        else
        {
            Game.Console.Print($"[Localization] There is no translation. Key: {key}");
            return NO_TRANSLATION;
        }
    }

    internal static string GetString(string key, params string[] vars)
    {
        if (Translation.ContainsKey(key)) return string.Format(Translation[key], vars);
        else
        {
            Game.Console.Print($"[Localization] There is no translation. Key: {key}");
            return NO_TRANSLATION;
        }
    }
}