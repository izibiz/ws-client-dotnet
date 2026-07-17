using System.Net.Http;
using System.Threading.Tasks;
using izibiz.REST.Strategy;

namespace izibiz.REST.Operations
{
    public class RestDownloadStrategy : IDownloadStrategy
    {
        private readonly HttpClient _httpClient;
        private readonly string _resourcePath;

        public RestDownloadStrategy(HttpClient httpClient, string resourcePath)
        {
            _httpClient = httpClient;
            _resourcePath = resourcePath; // e.g. "/v2/esmms"
        }

        public async Task<byte[]> DownloadAsync(string id, string format)
        {
            var url = $"{_resourcePath}/{id}/view/{format.ToLower()}";

            var response = await _httpClient.GetAsync(url);
            
            if (!response.IsSuccessStatusCode)
            {
                string err = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"HTTP {(int)response.StatusCode} Hatası!\nURL: {url}\nDetay: {err}");
            }

            return await response.Content.ReadAsByteArrayAsync();
        }
    }
}
