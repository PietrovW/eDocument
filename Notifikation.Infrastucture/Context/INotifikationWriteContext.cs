using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Notifikation.Infrastructure.Context
{
    public interface INotifikationWriteContext
    {
        Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default);
    }
}
