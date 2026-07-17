using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using izibiz.REST.Models;

namespace izibiz.REST.Infrastructure
{
    public class TokenProvider //token almak ve geri döndürmek.
    {
        private readonly RestApiOptions _options;
        private string _cachedToken;

        public TokenProvider(RestApiOptions options)
        {
            _options = options;
        }

        public async Task<string> GetTokenAsync()
        {
            if (_cachedToken != null)
                return _cachedToken;

            using (var httpClient = new HttpClient())
            {
                var url = $"{_options.BaseUrl}/v1/auth/token";
                var body = new { username = _options.Username, password = _options.Password };
                var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();

                var responseJson = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonSerializer.Deserialize<ApiResponse<TokenResponse>>(responseJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                _cachedToken = apiResponse.Data.AccessToken;
                return _cachedToken;
            }
        }
    }

    public class TokenResponse
    {
        public string AccessToken { get; set; }
    }
}