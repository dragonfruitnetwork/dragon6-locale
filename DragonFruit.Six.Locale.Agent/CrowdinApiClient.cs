using System;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using DragonFruit.Common.Data;
using DragonFruit.Common.Data.Serializers;
using DragonFruit.Six.Locale.Agent.Crowdin;
using DragonFruit.Six.Locale.Agent.Crowdin.Requests;

namespace DragonFruit.Six.Locale.Agent
{
    internal class CrowdinApiClient : ApiClient
    {
        public CrowdinApiClient()
        {
            UserAgent = "Dragon6";
            Serializer = new ApiXmlSerializer();
        }

        public string[] Login { get; set; }

        public T Perform<T>(CrowdinProjectRequest request, bool file = false, Action<long, long?> progressUpdated = null) where T : class
        {
            request.Username = Login[0];
            request.AccountKey = Login[1];

            if (!file)
            {
                return base.Perform<T>(request);
            }

            base.Perform(request, progressUpdated);
            return null;
        }

        protected override void SetupClient(HttpClient client, bool clientReset)
        {
            if (clientReset)
            {
                client.Timeout = TimeSpan.FromMinutes(2);
            }
        }
    }
}