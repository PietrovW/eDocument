using eDocument.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OCR.Infrastructure.Entitys;

namespace OCR.Infrastructure.EntityTypeConfigurations
{
    public class AttachmentEntityTypeConfigurations : IEntityTypeConfiguration<DocumentEntity>
    {
        public void Configure(EntityTypeBuilder<DocumentEntity> builder)
        {
            builder.ToTable("Attachments", "OCR");
            builder.ConfigurationBaseEntity();
            builder.Property(p => p.Content).IsRequired();
        }
    }
}
