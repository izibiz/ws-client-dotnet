using System.Collections.Generic;
using System.Threading.Tasks;

namespace izibiz.REST.Strategy
{
    public interface IDownloadStrategy
    {
        Task<Dictionary<string, byte[]>> DownloadAsync(List<string> ids, string format);
    }
}
