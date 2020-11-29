using eDocument.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notifikation.Infrastructure.Entity;

namespace Notifikation.Infrastructure.EntityTypeConfigurations
{
    public class NotifikationEntityTypeConfigurations : IEntityTypeConfiguration<NotifikationEntity>
    {
        public void Configure(EntityTypeBuilder<NotifikationEntity> builder)
        {
           builder.ToTable("Notifikations", "Notifikation");
           builder.ConfigurationBaseEntity();
           builder.Property(s => s.Message).IsRequired(false);
        }
    }
}
