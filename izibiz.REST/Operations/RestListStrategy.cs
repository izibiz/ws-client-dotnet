using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using izibiz.REST.Models;
using izibiz.REST.Models.Request;
using izibiz.REST.Strategy;

namespace izibiz.REST.Operations
{
    public class RestListStrategy<TItem> : IListStrategy<TItem>
    {
        private readonly HttpClient _httpClient;
        private readonly string _resourcePath;

        public RestListStrategy(HttpClient httpClient, string resourcePath)
        {
            _httpClient = httpClient;
            _resourcePath = resourcePath;
        }

        public async Task<PagedResult<TItem>> ListAsync(ListFilter filter)
        {
            var url = $"{_resourcePath}?page={filter.Page}&pageSize={filter.PageSize}";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonSerializer.Deserialize<ApiResponse<PagedResult<TItem>>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return apiResponse.Data;
        }
    }
}