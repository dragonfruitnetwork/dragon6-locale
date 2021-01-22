// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under MIT. Please refer to the LICENSE file for more info

using System.Xml.Serialization;

namespace DragonFruit.Six.Locale.Agent.Crowdin
{
    [XmlRoot(ElementName = "error")]
    public class CrowdinProjectErrorResult
    {
        [XmlElement(ElementName = "code")]
        public string Code { get; set; }

        [XmlElement(ElementName = "message")]
        public string Message { get; set; }
    }
}
