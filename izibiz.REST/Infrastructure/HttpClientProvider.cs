using System;
using System.Net.Http;

namespace izibiz.REST.Infrastructure
{
    public static class HttpClientProvider
    {
        public static HttpClient Create(RestApiOptions options, TokenProvider tokenProvider)
        {
            var handler = new BearerTokenHandler(tokenProvider)
            {
                InnerHandler = new HttpClientHandler()
            };

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(options.BaseUrl)
            };

            httpClient.DefaultRequestHeaders.Add("Accept-Language", "tr-TR");
            httpClient.DefaultRequestHeaders.Add("Client-Type", "ERP");
            httpClient.DefaultRequestHeaders.Add("Erp-Code", options.ErpCode);

            return httpClient;
        }
    }
}