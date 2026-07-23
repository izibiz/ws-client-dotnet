using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using izibiz.REST.Models.Request;
using izibiz.REST.Strategy;

namespace izibiz.REST.Operations
{
    public class RestAssignNumberStrategy : IAssignNumberStrategy
    {
        private readonly HttpClient _httpClient;
        private readonly string _resourcePath;

        public RestAssignNumberStrategy(HttpClient httpClient, string resourcePath)
        {
            _httpClient = httpClient;
            _resourcePath = resourcePath; // e.g. "/v2/esmms"
        }

        public async Task<bool> AssignNumberAsync(List<long> documentIds, string prefix, bool autoSend)
        {
            if (documentIds == null || documentIds.Count == 0 || string.IsNullOrEmpty(prefix))
                return false;

            var url = $"{_resourcePath}/id-assign/async";
            var requestBody = new AssignNumberRequest
            {
                Documents = documentIds,
                Prefix = prefix,
                AutoSend = autoSend
            };

            var json = JsonSerializer.Serialize(requestBody, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(url, content);
            return response.IsSuccessStatusCode;
        }
    }
}
