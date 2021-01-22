// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under MIT. Please refer to the LICENSE file for more info

namespace DragonFruit.Six.Locale.Agent.Crowdin.Requests
{
    internal class CrowdinProjectBuildRequest : CrowdinProjectRequest
    {
        protected override string Action => "export";
    }
}
