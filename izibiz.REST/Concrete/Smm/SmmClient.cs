using System.Net.Http;
using System.Threading.Tasks;
using izibiz.REST.Infrastructure;
using izibiz.REST.Models;
using izibiz.REST.Models.Request;
using izibiz.REST.Operations;
using izibiz.REST.Strategy;

namespace izibiz.REST.Concrete.Smm
{
    public class SmmClient : IListStrategy<SmmListItem>, IViewStrategy, IDownloadStrategy
    {
        private readonly RestListStrategy<SmmListItem> _listStrategy;
        private readonly RestViewStrategy _viewStrategy;
        private readonly RestDownloadStrategy _downloadStrategy;

        public SmmClient(HttpClient httpClient, RestApiOptions options)
        {
            // SMM'in API'deki adresi: /v2/esmms/outbox
            string basePath = $"/{options.Version}/esmms/outbox";
            
            _listStrategy = new RestListStrategy<SmmListItem>(httpClient, basePath);
            _viewStrategy = new RestViewStrategy(httpClient, basePath);
            _downloadStrategy = new RestDownloadStrategy(httpClient, basePath);
        }

        public Task<PagedResult<SmmListItem>> ListAsync(ListFilter filter)
        {
            return _listStrategy.ListAsync(filter);
        }

        /// <summary>
        /// Belgeyi ekranda önizlemek için GET /view/html ile çeker.
        /// Sadece HTML önizleme — format sabittir.
        /// </summary>
        public Task<byte[]> ViewAsync(string id)
        {
            return _viewStrategy.ViewAsync(id);
        }

        /// <summary>
        /// Belgeyi diske kaydetmek için POST /download ile indirir.
        /// </summary>
        public Task<byte[]> DownloadAsync(string id, string format)
        {
            return _downloadStrategy.DownloadAsync(id, format);
        }
    }
}
