using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace eDocument.Infrastructure.Repositories
{
    using eDocument.Infrastructure.Entity;
    using eDocument.Infrastructure.Specification;

    public class ReadRepository : IReadRepository 
    {
        private readonly DbContext _context;
        public ReadRepository(DbContext context)
        {
            _context = context;
        }

        public bool Contains<TEntity>(ISpecification<TEntity> specification) where TEntity : BaseEntity
        {
            return Count(specification) > 0 ? true : false;
        }

        public int Count<TEntity>(ISpecification<TEntity> specification) where TEntity : BaseEntity
        {
            return ApplySpecification(specification).Count();
        }

        public IEnumerable<TEntity> Find<TEntity>(ISpecification<TEntity> specification) where TEntity : BaseEntity
        {
            return ApplySpecification(specification);
        }

        public TEntity FindSingle<TEntity>(ISpecification<TEntity> specification) where TEntity : BaseEntity
        {
            return ApplySpecification(specification).SingleOrDefault();
        }
        private IQueryable<TEntity> ApplySpecification<TEntity>(ISpecification<TEntity> spec) where TEntity : BaseEntity
        {
            return SpecificationEvaluator.GetQuery(_context.Set<TEntity>().AsQueryable(), spec);
        }
    }
}
