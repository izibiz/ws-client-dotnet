using System.Net.Http;
using System.Threading.Tasks;
using izibiz.REST.Infrastructure;
using izibiz.REST.Models;
using izibiz.REST.Models.Request;
using izibiz.REST.Operations;
using izibiz.REST.Strategy;

namespace izibiz.REST.Concrete.Smm
{
    public class SmmClient : IListStrategy<SmmListItem>, IDownloadStrategy
    {
        private readonly RestListStrategy<SmmListItem> _listStrategy;
        private readonly RestDownloadStrategy _downloadStrategy;

        public SmmClient(HttpClient httpClient, RestApiOptions options)
        {
            // SMM'in API'deki adresi: /v2/esmms
            string basePath = $"/{options.Version}/esmms/outbox";
            
            _listStrategy = new RestListStrategy<SmmListItem>(httpClient, basePath);
            _downloadStrategy = new RestDownloadStrategy(httpClient, basePath);
        }

        public Task<PagedResult<SmmListItem>> ListAsync(ListFilter filter)
        {
            return _listStrategy.ListAsync(filter);
        }

        public Task<byte[]> DownloadAsync(string uuid, string format)
        {
            return _downloadStrategy.DownloadAsync(uuid, format);
        }
    }
}
