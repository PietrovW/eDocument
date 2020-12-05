using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OCR.Infrastructure.EntityTypeConfigurations
{
    using eDocument.Infrastructure.Extensions;
    using OCR.Infrastructure.Entitys;
    public class DocumentEntityTypeConfigurations : IEntityTypeConfiguration<DocumentEntity>
    {
        public void Configure(EntityTypeBuilder<DocumentEntity> builder)
        {
            builder.ToTable("Attachments", "OCR");
            builder.ConfigurationBaseEntity();
            builder.Property(p => p.FileName).IsUnicode().IsRequired();
            builder.Property(p => p.Content).IsRequired();
            builder.Property(p => p.Bytes).IsRequired();
        }
    }
}
