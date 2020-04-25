using DocumentTracking.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentTracking.Infrastructure.Data.Config
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.Property(b => b.Name)
                .IsRequired();
            builder.Property(b => b.Type)
                .IsRequired();
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
