using System;

namespace DragonFruit.Six.Locale.Agent.Crowdin.Requests
{
    internal class CrowdinProjectDownloadRequest : CrowdinProjectRequest
    {
        private string _destination;

        protected override string Action => "download/all.zip";

        public override string Destination => _destination ??= System.IO.Path.Combine(System.IO.Path.GetTempPath(), $"dragon6-locale-{Guid.NewGuid().ToString().Substring(0, 12)}.zip");
    }
}