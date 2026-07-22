using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using izibiz.REST.Infrastructure;
using izibiz.REST.Models;
using izibiz.REST.Models.Request;
using izibiz.REST.Operations;
using izibiz.REST.Strategy;

namespace izibiz.REST.Concrete.Smm
{
    public class SmmClient : IListStrategy<SmmListItem>, IViewStrategy, IDownloadStrategy, ICancelStrategy
    {
        private readonly IListStrategy<SmmListItem> _listStrategy;
        private readonly IViewStrategy _viewStrategy;
        private readonly IDownloadStrategy _downloadStrategy;
        private readonly ICancelStrategy _cancelStrategy;

        public SmmClient(HttpClient httpClient, RestApiOptions options)
        {
            // SMM'in API'deki adresi: /v2/esmms/outbox
            string basePath = $"/{options.Version}/esmms/outbox";
            string cancelPath = $"/{options.Version}/esmms";
            
            _listStrategy = new RestListStrategy<SmmListItem>(httpClient, basePath);
            _viewStrategy = new RestViewStrategy(httpClient, basePath);
            _downloadStrategy = new RestDownloadStrategy(httpClient, basePath);
            _cancelStrategy = new RestCancelStrategy(httpClient, cancelPath);
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
        public Task<Dictionary<string, byte[]>> DownloadAsync(List<string> ids, string format)
        {
            return _downloadStrategy.DownloadAsync(ids, format);
        }

        /// <summary>
        /// Belgeyi iptal eder.
        /// </summary>
        public Task CancelAsync(string id, bool deleteDocument = false)
        {
            return _cancelStrategy.CancelAsync(id, deleteDocument);
        }
    }
}
