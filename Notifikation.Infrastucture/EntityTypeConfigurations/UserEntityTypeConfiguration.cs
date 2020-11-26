using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notifikation.Domain.Models;

namespace Notifikation.Infrastructure.EntityTypeConfigurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.ToTable("Users", "Notifikation");
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Email).IsRequired();
        }
    }
}
