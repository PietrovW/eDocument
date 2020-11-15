using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Notifikation.Infrastructure.Context
{
    public class NotifikationWriteContext : INotifikationWriteContext
    {
        private readonly NotifikationContext context;
        public NotifikationWriteContext(NotifikationContext context)
        {
            this.context = context;
        }
        public async Task<int> ExecuteAsync(string sql, object param = null, System.Data.IDbTransaction transaction = null, System.Threading.CancellationToken cancellationToken = default)
        {
            return await context.Database.GetDbConnection().ExecuteAsync(sql, param, transaction);
        }
        public async Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object param = null, System.Data.IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return (await context.Database.GetDbConnection().QueryAsync<T>(sql, param, transaction)).AsList();
        }
        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, System.Data.IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return await context.Database.GetDbConnection().QueryFirstOrDefaultAsync<T>(sql, param, transaction);
        }
        public async Task<T> QuerySingleAsync<T>(string sql, object param = null, System.Data.IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return await context.Database.GetDbConnection().QuerySingleAsync<T>(sql, param, transaction);
        }
    }
}
