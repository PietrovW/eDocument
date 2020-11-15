using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Notifikation.Infrastructure.Data
{
    public class OCRDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            
        }

        public override int SaveChanges()
        {
           // UpdateAuditEntities();
            return base.SaveChanges();
        }

        private void UpdateAuditEntities()
        {
            //var modifiedEntries = ChangeTracker.Entries()
            //    .Where(x => x.Entity is IBaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));


            //foreach (var entry in modifiedEntries)
            //{
            //    var entity = (IBaseEntity)entry.Entity;
            //    DateTime now = DateTime.UtcNow;

            //    if (entry.State == EntityState.Added)
            //    {
            //        entity.CreatedDate = now;
            //        entity.CreatedBy = CurrentUserId;
            //    }
            //    else
            //    {
            //        base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
            //        base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
            //    }

            //    entity.UpdatedDate = now;
            //    entity.UpdatedBy = CurrentUserId;
            //}
        }
    }
}
