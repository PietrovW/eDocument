﻿using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace eDocument.Infrastructure.Specification
{
    using eDocument.Infrastructure.Entity;
    public class SpecificationEvaluator 
    {
        public static IQueryable<TEntity> GetQuery<TEntity>(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification) where TEntity : BaseEntity
        {
            var query = inputQuery;

            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            query = specification.Includes.Aggregate(query,
                                    (current, include) => current.Include(include));

            query = specification.IncludeStrings.Aggregate(query,
                                    (current, include) => current.Include(include));

            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }
            else if (specification.OrderByDescending != null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }

            if (specification.GroupBy != null)
            {
                query = query.GroupBy(specification.GroupBy).SelectMany(x => x);
            }

            if (specification.IsPagingEnabled)
            {
                query = query.Skip(specification.Skip)
                                .Take(specification.Take);
            }
            return query;
        }
    }
}
