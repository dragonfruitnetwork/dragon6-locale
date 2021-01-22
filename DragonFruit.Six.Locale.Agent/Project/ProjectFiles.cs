using System.Collections.Generic;

namespace DragonFruit.Six.Locale.Agent.Project
{
    public class ProjectFiles
    {
        public static IReadOnlyDictionary<string, string[]> PathMapping = new Dictionary<string, string[]>
        {
            ["Errors"] = new[] {"Apps"},
            ["Interface"] = new[] {"Apps"},

            ["Titles"] = new[] {"Apps", "Cards"},
            ["Descriptions"] = new[] {"Apps", "Cards"},

            ["Ranks"] = new[] {"Objects"},
            ["Weapons"] = new[] {"Objects"}
        };
    }
}