using System.Net.Http;
using System.Threading.Tasks;
using izibiz.REST.Infrastructure;
using izibiz.REST.Models;
using izibiz.REST.Models.Request;
using izibiz.REST.Operations;
using izibiz.REST.Strategy;

namespace izibiz.REST.Concrete.Mustahsil
{
    public class MustahsilClient : IListStrategy<MustahsilListItem>, IViewStrategy, IDownloadStrategy
    {
        private readonly RestListStrategy<MustahsilListItem> _listStrategy;
        private readonly RestViewStrategy _viewStrategy;
        private readonly RestDownloadStrategy _downloadStrategy;

        public MustahsilClient(HttpClient httpClient, RestApiOptions options)
        {
            string basePath = $"/{options.Version}/ecreditnotes/outbox";

            _listStrategy = new RestListStrategy<MustahsilListItem>(httpClient, basePath);
            _viewStrategy = new RestViewStrategy(httpClient, basePath);
            _downloadStrategy = new RestDownloadStrategy(httpClient, basePath);
        }

        public Task<PagedResult<MustahsilListItem>> ListAsync(ListFilter filter)
        {
            return _listStrategy.ListAsync(filter);
        }

        public Task<byte[]> ViewAsync(string id)
        {
            return _viewStrategy.ViewAsync(id);
        }

        public Task<byte[]> DownloadAsync(string id, string format)
        {
            return _downloadStrategy.DownloadAsync(id, format);
        }
    }
}