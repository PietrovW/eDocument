using eDocument.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eDocument.Infrastructure.Extensions
{
    public static class BaseEntityExtensions
    {
        public static EntityTypeBuilder<TEntity> ConfigurationBaseEntity<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : BaseEntity
        {
            // builder.HasPostgresExtension("uuid-ossp");
            builder.HasKey(k => k.Id);
            builder.UseXminAsConcurrencyToken();
            builder.Property(p => p.DateCreated).ValueGeneratedOnAdd();
            builder.Property(p => p.DateUpdate).ValueGeneratedOnAddOrUpdate();
            return builder;
        }
    }
}
