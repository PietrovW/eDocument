using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notifikation.Domain.Models;

namespace Notifikation.Infrastructure.EntityTypeConfigurations
{
    public class AttachmentEntityTypeConfigurations : IEntityTypeConfiguration<AttachmentModel>
    {
        public void Configure(EntityTypeBuilder<AttachmentModel> builder)
        {
            builder.ToTable("Attachments", "Notifikation");
            
        }
    }
}
