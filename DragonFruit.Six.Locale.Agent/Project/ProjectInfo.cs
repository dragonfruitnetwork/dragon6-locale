// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under MIT. Please refer to the LICENSE file for more info

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
            "uk",
            "zh-TW" // chinese (taiwan)
        };

        public static IReadOnlyDictionary<string, string> LocaleMapping = new Dictionary<string, string>
        {
            ["es-ES"] = "es"
        };
    }
}
