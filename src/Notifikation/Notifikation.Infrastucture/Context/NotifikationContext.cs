using Microsoft.EntityFrameworkCore;
using Notifikation.Infrastructure.Entity;
using Notifikation.Infrastructure.EntityTypeConfigurations;
using System.Data;

namespace Notifikation.Infrastructure.Context
{
    public class NotifikationContext : DbContext
    {

        public NotifikationContext(DbContextOptions<NotifikationContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new AttachmentEntityTypeConfigurations());
            builder.ApplyConfiguration(new NotifikationEntityTypeConfigurations());
            builder.ApplyConfiguration(new UserEntityTypeConfiguration());
        }

        public DbSet<NotifikationEntity> Notifikations { get; set; }
        public DbSet<AttachmentEntity> Attachments { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public IDbConnection Connection => Database.GetDbConnection();

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
