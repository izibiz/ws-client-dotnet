using System.Threading.Tasks;
using izibiz.REST.Models;
using izibiz.REST.Models.Request;

namespace izibiz.REST.Strategy
{
    public interface IListStrategy<TItem>
    {
        Task<PagedResult<TItem>> ListAsync(ListFilter filter);
    }
}