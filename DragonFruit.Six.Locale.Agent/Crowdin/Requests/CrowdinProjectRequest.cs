// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under MIT. Please refer to the LICENSE file for more info

using DragonFruit.Common.Data;
using DragonFruit.Common.Data.Parameters;

namespace DragonFruit.Six.Locale.Agent.Crowdin.Requests
{
    internal abstract class CrowdinProjectRequest : ApiFileRequest
    {
        public override string Path => $"https://api.crowdin.com/api/project/dragon6/{Action}";
        public override string Destination => string.Empty;

        protected abstract string Action { get; }

        [QueryParameter("login")]
        public string Username { get; set; }

        [QueryParameter("account-key")]
        public string AccountKey { get; set; }
    }
}
