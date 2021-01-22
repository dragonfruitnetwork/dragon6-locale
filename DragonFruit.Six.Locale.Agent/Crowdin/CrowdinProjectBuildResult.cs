using System;
using System.Xml.Serialization;

namespace DragonFruit.Six.Locale.Agent.Crowdin
{
    [XmlRoot(ElementName = "success")]
    public class CrowdinProjectBuildResult
    {
        [XmlAttribute(AttributeName = "status")]
        private string StatusName
        {
            get => Status.ToString().ToLowerInvariant();
            set => Enum.Parse<BuildStatus>(value, true);
        }

        [XmlIgnore]
        public BuildStatus Status { get; set; }
    }

    public enum BuildStatus
    {
        Built,
        Skipped
    }
}