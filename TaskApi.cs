using Microsoft.Extensions.Logging;
using Microsoft.Playwright;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace WorkflowSpecflowTests.Apis
{
    public interface ITaskApi
    {
        Task<List<ListOfTasksDTO>> CallTaskApiAsync(string lastTaskId);
    }

    public class TaskApi : ITaskApi
    {
        private static string tokenUrl = "https://login.microsoft.com/dfbcc178-bccf-4595-8f8e-3a3175df90b7/oauth2/v2.0/token";
        private static string clientId = "ce8c3735-7a19-4b10-8f10-f92197d6329e";
        private static string clientSecret = "4Zw8Q~cEVh5Sks6d4MjyJmy05KTWWEgKwPtMvdnq";
        private static string scope = "https://graph.microsoft.com/.default";

        private async Task<string> GetAccessTokenAsync()
        {
            var client = new RestClient(tokenUrl);
            var request = new RestRequest("/", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            // Add OAuth2 required fields
            request.AddParameter("grant_type", "client_credentials");
            request.AddParameter("client_id", clientId);
            request.AddParameter("client_secret", clientSecret);
            request.AddParameter("scope", scope);

            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                var json = JObject.Parse(response.Content);
                return json["access_token"].ToString();
            }
            else
            {
                throw new System.Exception("Unable to retrieve access token: " + response.ErrorMessage);
            }
        }

        public async Task<List<ListOfTasksDTO>> CallTaskApiAsync(string lastTaskId)
        {
            string accessToken = await GetAccessTokenAsync();

            var client = new RestClient("https://uk-devtest.nexus.hiscox.com/in1/uk/C00061v1/svc/workflow/v1/tasks/" + lastTaskId);
            var request = new RestRequest("/", Method.Get);
            request.AddHeader("Authorization", "Bearer " + accessToken);
            request.AddHeader("Ocp-Apim-Subscription-Key", "ba6c5fa4b91b4c3cbb9689992ecfa658");
            request.AddHeader("Nxs-CountryCode", "uk");
            request.AddHeader("Nxs-Channel", "direct");
            request.AddHeader("Nxs-SourceSystem", "IDIT");
            request.AddHeader("Nxs-Username", "Workflow");

            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                var apiResponse = JsonConvert.DeserializeObject<List<ListOfTasksDTO>>(response.Content);
                return apiResponse;
            }
            return null;
        }
    }
}
