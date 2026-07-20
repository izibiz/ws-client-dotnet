using System.Threading.Tasks;

namespace izibiz.REST.Strategy
{
    /// <summary>
    /// Belgeyi ekranda önizlemek için kullanılır.
    /// GET /{id}/view/html endpoint'ine istek atar.
    /// Sadece HTML önizleme destekler, format sabittir.
    /// </summary>
    public interface IViewStrategy
    {
        Task<byte[]> ViewAsync(string id);
    }
}
