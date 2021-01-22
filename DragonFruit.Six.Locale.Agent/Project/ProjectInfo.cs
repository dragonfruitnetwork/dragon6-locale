using System.Collections.Generic;

namespace DragonFruit.Six.Locale.Agent.Project
{
    internal static class ProjectInfo
    {
        public const string Id = "dragon6";
        
        public static readonly string[] SupportedLocales =
        {
            "cs",
            "es-ES",
            "fr",
            "id",
            "it",
            "no",
            "pl",
            "pt-PT",
            "pt-BR",
            "ru",
            "tr",
            "zh-TW" // traditional chinese
        };

        public static IReadOnlyDictionary<string, string> LocaleMapping = new Dictionary<string, string>
        {
            ["es-ES"] = "es"
        };
    }
}