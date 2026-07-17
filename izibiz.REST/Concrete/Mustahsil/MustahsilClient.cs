using System.Net.Http;
using System.Threading.Tasks;
using izibiz.REST.Infrastructure;
using izibiz.REST.Models;
using izibiz.REST.Models.Request;
using izibiz.REST.Operations;
using izibiz.REST.Strategy;

namespace izibiz.REST.Concrete.Mustahsil
{
    public class MustahsilClient : IListStrategy<MustahsilListItem>
    {
        private readonly RestListStrategy<MustahsilListItem> _listStrategy;

        public MustahsilClient(HttpClient httpClient, RestApiOptions options)
        {
            _listStrategy = new RestListStrategy<MustahsilListItem>(httpClient, $"/{options.Version}/ecreditnotes/outbox");
        }

        public Task<PagedResult<MustahsilListItem>> ListAsync(ListFilter filter)
        {
            return _listStrategy.ListAsync(filter);
        }
    }
}