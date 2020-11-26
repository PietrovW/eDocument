using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notifikation.Domain.Models;

namespace Notifikation.Infrastructure.EntityTypeConfigurations
{
    public class NotifikationEntityTypeConfigurations : IEntityTypeConfiguration<NotifikationModel>
    {
        public void Configure(EntityTypeBuilder<NotifikationModel> builder)
        {
           builder.ToTable("Notifikations", "Notifikation");
           builder.Property(s => s.Message).IsRequired(false);
        }
    }
}
