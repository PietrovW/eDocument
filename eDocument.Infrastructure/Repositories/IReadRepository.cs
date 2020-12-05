
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace eDocument.Infrastructure.Repositories
{
    using eDocument.Infrastructure.Entity;
    using eDocument.Infrastructure.Specification;

    public interface IReadRepository 
    {
        TEntity FindSingle<TEntity>(ISpecification<TEntity> specification) where TEntity : BaseEntity;
        IEnumerable<TEntity> Find<TEntity>(ISpecification<TEntity> specification) where TEntity : BaseEntity;
        bool Contains<TEntity>(ISpecification<TEntity> specification) where TEntity : BaseEntity;
        int Count<TEntity>(ISpecification<TEntity> specification) where TEntity : BaseEntity;
    }
}