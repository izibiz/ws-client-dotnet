using System.Net.Http;
using System.Threading.Tasks;
using izibiz.REST.Strategy;

namespace izibiz.REST.Operations
{
    /// <summary>
    /// GET /{id}/view/html endpoint'ine istek atarak
    /// belgenin saf HTML içeriğini döndürür.
    /// Ekranda hızlı önizleme için kullanılır.
    /// Format her zaman HTML'dir, parametre olarak alınmaz.
    /// ID, URL'nin içine gömülür (body yok).
    /// </summary>
    public class RestViewStrategy : IViewStrategy
    {
        private readonly HttpClient _httpClient;
        private readonly string _resourcePath;

        public RestViewStrategy(HttpClient httpClient, string resourcePath)
        {
            _httpClient = httpClient;
            _resourcePath = resourcePath; // e.g. "/v2/esmms/outbox"
        }

        public async Task<byte[]> ViewAsync(string id)
        {
            // Postman: GET {{baseUrl}}/{{v2}}/esmms/outbox/2002553/view/html
            // ID → URL'de, format → sabit "html", body → yok
            var url = $"{_resourcePath}/{id}/view/html";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                string err = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"View HTTP {(int)response.StatusCode} Hatası!\nURL: {url}\nDetay: {err}");
            }

            return await response.Content.ReadAsByteArrayAsync();
        }
    }
}
