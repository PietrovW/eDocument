using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notifikation.Infrastructure.Entity;

namespace Notifikation.Infrastructure.EntityTypeConfigurations
{
    public class AttachmentEntityTypeConfigurations : IEntityTypeConfiguration<AttachmentEntity>
    {
        public void Configure(EntityTypeBuilder<AttachmentEntity> builder)
        {
            builder.ToTable("Attachments", "Notifikation");
            builder.HasKey(e => e.Id);
            builder.Property(p => p.Content).IsRequired();
        }
    }
}
