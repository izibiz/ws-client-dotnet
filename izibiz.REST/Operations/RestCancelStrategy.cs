using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using izibiz.REST.Strategy;

namespace izibiz.REST.Operations
{

    public class RestCancelStrategy : ICancelStrategy
    {
        private readonly HttpClient _httpClient;
        private readonly string _resourcePath;

        public RestCancelStrategy(HttpClient httpClient, string resourcePath)
        {
            _httpClient = httpClient;
            _resourcePath = resourcePath; // e.g. "/v2/ecreditnotes"
        }

        public async Task CancelAsync(string uuid, bool deleteDocument = false)
        {
            var url = $"{_resourcePath}/cancel";
            var body = $"[{{\"uuid\":\"{uuid}\",\"deleteDocument\":{deleteDocument.ToString().ToLower()}}}]";
            var content = new StringContent(body, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Delete, url) { Content = content };
            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                string err = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Cancel HTTP {(int)response.StatusCode} Hatası!\nURL: {url}\nDetay: {err}");
            }
        }
    }
}