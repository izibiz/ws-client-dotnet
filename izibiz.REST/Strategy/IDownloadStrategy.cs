using System.Threading.Tasks;

namespace izibiz.REST.Strategy
{
    public interface IDownloadStrategy
    {
        Task<byte[]> DownloadAsync(string uuid, string format);
    }
}
