using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using izibiz.REST.Strategy;

namespace izibiz.REST.Operations
{
    /// <summary>
    /// POST /download/{format} endpoint'ine istek atarak
    /// belgeyi ZIP içinde Base64 olarak indirir.
    /// Diske kaydetmek için kullanılır (HTML, PDF, UBL).
    /// </summary>
    public class RestDownloadStrategy : IDownloadStrategy
    {
        private readonly HttpClient _httpClient;
        private readonly string _resourcePath;

        public RestDownloadStrategy(HttpClient httpClient, string resourcePath)
        {
            _httpClient = httpClient;
            _resourcePath = resourcePath; // e.g. "/v2/esmms/outbox"
        }

        public async Task<byte[]> DownloadAsync(string id, string format)
        {
            // Postman: POST {{baseUrl}}/{{v2}}/esmms/outbox/download/html
            // Body: [{"id":2002553}]
            var url = $"{_resourcePath}/download/{format.ToLower()}";
            var body = $"[{{\"id\":{id}}}]";
            var content = new StringContent(body, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                string err = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Download HTTP {(int)response.StatusCode} Hatası!\nURL: {url}\nDetay: {err}");
            }

            return await response.Content.ReadAsByteArrayAsync();
        }
    }
}
