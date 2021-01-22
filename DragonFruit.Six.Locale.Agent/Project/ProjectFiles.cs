// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under MIT. Please refer to the LICENSE file for more info

using System.Collections.Generic;

namespace DragonFruit.Six.Locale.Agent.Project
{
    public class ProjectFiles
    {
        public static IReadOnlyDictionary<string, string[]> PathMapping = new Dictionary<string, string[]>
        {
            ["Errors"] = new[] { "Apps" },
            ["Interface"] = new[] { "Apps" },

            ["Titles"] = new[] { "Apps", "Cards" },
            ["Descriptions"] = new[] { "Apps", "Cards" },

            ["Ranks"] = new[] { "Objects" },
            ["Weapons"] = new[] { "Objects" }
        };
    }
}
