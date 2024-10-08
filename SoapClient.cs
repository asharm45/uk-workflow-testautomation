using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WorkflowSpecflowTests.Apis
{
    public interface ISoapClient
    {
        Task<XDocument> DeleteCall();
        Task<XDocument> GetCall();
        Task<XDocument> PostCall(string payload);
        Task<XDocument> PutCall(string payload);
        Task SetUrl(string url);
    }

    public class SoapClient : ISoapClient
    {
        private HttpClient _httpClient;
        private string _url;
        public async Task SetUrl(string url)
        {
            _httpClient = new HttpClient();
            _url = url;
        }
        public async Task<XDocument> PostCall(string payload)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(_url),
                Content = new StringContent(payload, Encoding.UTF8, "text/xml")
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return XDocument.Parse(responseContent);
        }

        public async Task<XDocument> GetCall()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(_url),
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return XDocument.Parse(responseContent);
        }

        public async Task<XDocument> PutCall(string payload)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri(_url),
                Content = new StringContent(payload, Encoding.UTF8, "text/xml")
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return XDocument.Parse(responseContent);
        }

        public async Task<XDocument> DeleteCall()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(_url),
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return XDocument.Parse(responseContent);
        }
    }
}
