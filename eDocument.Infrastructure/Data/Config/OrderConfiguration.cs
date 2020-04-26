using eDocument.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eDocument.Infrastructure.Data.Config
{
    class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.Comments).HasMaxLength(500);
            builder.ToTable($"AppOrders");
        }
    }
}
