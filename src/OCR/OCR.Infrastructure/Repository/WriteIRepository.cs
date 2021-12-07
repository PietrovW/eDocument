using eDocument.Infrastructure.Entity;
using eDocument.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Notifikation.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace OCR.Infrastructure.Repositories
{
    public class WriteIRepository: IWriteIRepository
    {
        private readonly OCRDbContext _context;
        public WriteIRepository(OCRDbContext context)
        {
            _context = context;
        }

        public void Add<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseEntity
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public void Remove<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseEntity
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            _context.Set<TEntity>().Attach(entity);
        }
        public async Task SaveChangesAsync( CommittableTransaction transaction = null)
        {
            if(transaction!= null)
            {
                await _context.Database.OpenConnectionAsync();
                _context.Database.EnlistTransaction(transaction);
            }

            await _context.SaveChangesAsync();
            if (transaction != null)
            {
                await _context.Database.CloseConnectionAsync();
            }
        }

        public void Commit(CommittableTransaction transaction)
        {
            try
            {
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
            }
            finally
            {
                transaction.Dispose();
            }
        }
    }
}
