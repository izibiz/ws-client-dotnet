using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using izibiz.REST.Strategy;

namespace izibiz.REST.Operations
{
    /// <summary>
    /// POST /download/{format} endpoint'ine istek atarak
    /// belgeyi ZIP içinde Base64 olarak indirir.
    /// Hafızada ZIP'i çözüp asıl dosyanın baytlarını döndürür.
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

        public async Task<Dictionary<string, byte[]>> DownloadAsync(List<string> ids, string format)
        {
            if (ids == null || ids.Count == 0)
                return new Dictionary<string, byte[]>();

            var url = $"{_resourcePath}/download/{format.ToLower()}";
            var idObjects = ids.Select(id => $"{{\"id\":{id}}}");
            var body = $"[{string.Join(",", idObjects)}]";
            var content = new StringContent(body, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                string err = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Download HTTP {(int)response.StatusCode} Hatası!\nURL: {url}\nDetay: {err}");
            }

            string jsonResponse = await response.Content.ReadAsStringAsync();
            
            // JSON'u parse et
            using (JsonDocument doc = JsonDocument.Parse(jsonResponse))
            {
                var root = doc.RootElement;
                if (root.TryGetProperty("data", out JsonElement dataElement) && 
                    dataElement.TryGetProperty("content", out JsonElement contentElement))
                {
                    string base64Zip = contentElement.GetString();
                    byte[] zipBytes = Convert.FromBase64String(base64Zip);

                    // ZIP'i hafızada aç ve asıl dosyayı çıkar
                    using (var memoryStream = new MemoryStream(zipBytes))
                    using (var archive = new ZipArchive(memoryStream))
                    {
                        var result = new Dictionary<string, byte[]>();

                        if (archive.Entries.Count > 0)
                        {
                            // İstenilen formata göre (pdf, xml, html) zipten doğru dosyayı bul
                            string targetExt = "." + format.ToLower();
                            if (targetExt == ".ubl") targetExt = ".xml"; // UBL = XML
                            
                            foreach(var e in archive.Entries)
                            {
                                if(e.FullName.EndsWith(targetExt, StringComparison.OrdinalIgnoreCase))
                                {
                                    using (var entryStream = e.Open())
                                    using (var ms = new MemoryStream())
                                    {
                                        await entryStream.CopyToAsync(ms);
                                        result[e.FullName] = ms.ToArray();
                                    }
                                }
                            }

                            // Eğer uzantı tutmadıysa ama dosya varsa hepsini al (fallback)
                            if (result.Count == 0 && archive.Entries.Count > 0)
                            {
                                foreach(var e in archive.Entries)
                                {
                                    using (var entryStream = e.Open())
                                    using (var ms = new MemoryStream())
                                    {
                                        await entryStream.CopyToAsync(ms);
                                        result[e.FullName] = ms.ToArray();
                                    }
                                }
                            }

                            if (result.Count > 0)
                            {
                                return result;
                            }
                        }
                    }
                }
            }

            throw new Exception("Sunucudan gelen yanıt geçerli bir ZIP/Base64 verisi içermiyor.");
        }
    }
}
