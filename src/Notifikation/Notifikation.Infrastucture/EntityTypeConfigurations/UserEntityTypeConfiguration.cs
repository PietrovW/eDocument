using eDocument.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notifikation.Infrastructure.Entity;

namespace Notifikation.Infrastructure.EntityTypeConfigurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users", "Notifikation");
            builder.ConfigurationBaseEntity();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Email).IsRequired();
        }
    }
}
