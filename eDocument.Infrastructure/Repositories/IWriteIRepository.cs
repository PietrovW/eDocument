using eDocument.Infrastructure.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace eDocument.Infrastructure.Repositories
{
    public interface IWriteIRepository
    {
        void Add<TEntity>(TEntity entity) where TEntity : BaseEntity;
        void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseEntity;

        void Remove<TEntity>(TEntity entity) where TEntity : BaseEntity;
        void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseEntity;

        void Update<TEntity>(TEntity entity) where TEntity : BaseEntity;

        Task SaveChangesAsync(CommittableTransaction transaction = null);
        void Commit(CommittableTransaction transaction);
    }
}
