using eDocument.Infrastructure.Entity;
using eDocument.Infrastructure.Repositories;
using System;


namespace eDocument.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        int Complete();
    }
}
