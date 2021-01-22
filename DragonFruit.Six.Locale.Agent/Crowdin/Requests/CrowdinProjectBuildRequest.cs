namespace DragonFruit.Six.Locale.Agent.Crowdin.Requests
{
    internal class CrowdinProjectBuildRequest : CrowdinProjectRequest
    {
        protected override string Action => "export";
    }
}