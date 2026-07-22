using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using izibiz.REST.Infrastructure;
using izibiz.REST.Models;
using izibiz.REST.Models.Request;
using izibiz.REST.Operations;
using izibiz.REST.Strategy;

namespace izibiz.REST.Concrete.Mustahsil
{
    public class MustahsilClient : IListStrategy<MustahsilListItem>, IViewStrategy, IDownloadStrategy, ICancelStrategy
    {
        private readonly RestListStrategy<MustahsilListItem> _listStrategy;
        private readonly RestListStrategy<MustahsilListItem> _draftListStrategy;
        private readonly RestViewStrategy _viewStrategy;
        private readonly RestDownloadStrategy _downloadStrategy;
        private readonly RestCancelStrategy _cancelStrategy;

        public MustahsilClient(HttpClient httpClient, RestApiOptions options)
        {
            string basePath = $"/{options.Version}/ecreditnotes/outbox";
            string draftPath = $"/{options.Version}/ecreditnotes/draft";
            string cancelPath = $"/{options.Version}/ecreditnotes";

            _listStrategy = new RestListStrategy<MustahsilListItem>(httpClient, basePath);
            _draftListStrategy = new RestListStrategy<MustahsilListItem>(httpClient, draftPath);
            _viewStrategy = new RestViewStrategy(httpClient, basePath);
            _downloadStrategy = new RestDownloadStrategy(httpClient, basePath);
            _cancelStrategy = new RestCancelStrategy(httpClient, cancelPath);
        }

        public Task<PagedResult<MustahsilListItem>> ListAsync(ListFilter filter)
        {
            return _listStrategy.ListAsync(filter);
        }

        public Task<PagedResult<MustahsilListItem>> ListDraftsAsync(ListFilter filter)
        {
            return _draftListStrategy.ListAsync(filter);
        }

        public Task<byte[]> ViewAsync(string id)
        {
            return _viewStrategy.ViewAsync(id);
        }

        public Task<Dictionary<string, byte[]>> DownloadAsync(List<string> ids, string format)
        {
            return _downloadStrategy.DownloadAsync(ids, format);
        }

        public Task CancelAsync(string uuid, bool deleteDocument = false)
        {
            return _cancelStrategy.CancelAsync(uuid, deleteDocument);
        }
    }
}