using System.Threading.Tasks;

namespace izibiz.REST.Strategy
{
    public interface ICancelStrategy
    {
        Task CancelAsync(string uuid, bool deleteDocument = false);
    }
}