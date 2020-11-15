using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Notifikation.Infrastructure.Context
{
    public class NotifikationReadContext : INotifikationReadContext
    {
        private readonly NotifikationContext context;
        public NotifikationReadContext(NotifikationContext context)
        {
            this.context = context;
        }

        public async Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, System.Threading.CancellationToken cancellationToken = default)
        {
            return (await context.Database.GetDbConnection().QueryAsync<T>(sql, param, transaction)).AsList();
        }
        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, System.Threading.CancellationToken cancellationToken = default)
        {
            return await context.Database.GetDbConnection().QueryFirstOrDefaultAsync<T>(sql, param, transaction);
        }
        public async Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null, System.Threading.CancellationToken cancellationToken = default)
        {
            return await context.Database.GetDbConnection().QuerySingleAsync<T>(sql, param, transaction);
        }
    }
}
