using RAGENativeUI;

namespace CleanWorldMenu;

internal static class Helpers
{
    internal static string ConvertToTwoCode(Language lang)
    {
        return lang switch
        {
            Language.English => "en-US",
            Language.French => "fr-FR",
            Language.German => "de-DE",
            Language.Italian => "it-IT",
            Language.Spanish => "es-ES",
            Language.BrazilianPortuguese => "pt-BR",
            Language.Polish => "pl-PL",
            Language.Russian => "ru-RU",
            Language.Korean => "ko-KR",
            Language.TraditionalChinese => "zn-TW",
            Language.Japanese => "ja-JP",
            Language.MexicanSpanish => "es-MX",
            Language.SimplifiedChinese => "zn-CN",
            _ => "en-US"
        };
    }
}