using DocumentTracking.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DocumentTracking.Infrastructure.Data.Config
{
    public class MetadaneConfiguration : IEntityTypeConfiguration<InvoiceItem>
    {
        public void Configure(EntityTypeBuilder<InvoiceItem> builder)
        {
            builder.Property<DateTimeOffset>("LastUpdated")
            .ValueGeneratedOnAddOrUpdate()
            .IsRequired();
            builder.Property<bool>("Available")
                .HasDefaultValue(true)
                .IsRequired();
            builder.Property<long>("User")
                .IsRequired();
            builder.Property<int>("Ver")
                .ValueGeneratedOnAddOrUpdate()
                .IsRequired();
        }
    }
}
