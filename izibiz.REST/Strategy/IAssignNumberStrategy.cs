using System.Collections.Generic;
using System.Threading.Tasks;

namespace izibiz.REST.Strategy
{
    public interface IAssignNumberStrategy
    {
        Task<bool> AssignNumberAsync(List<long> documentIds, string prefix, bool autoSend);
    }
}
