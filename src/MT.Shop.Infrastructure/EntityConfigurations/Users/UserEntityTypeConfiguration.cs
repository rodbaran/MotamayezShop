using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MT.Shop.Domain.Entities.Users;

namespace MT.Shop.Infrastructure.EntityConfigurations.Users;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {

        builder.HasKey(u => u.Id);

        builder.Property(u => u.FirstName)
               .IsRequired()
               .HasMaxLength(60)
               .HasColumnOrder(3);

        builder.Property(u => u.LastName)
               .IsRequired()
               .HasMaxLength(60)
               .HasColumnOrder(4);

        builder.Property(u => u.Email)
               .IsRequired()
               .HasMaxLength(60)
               .HasColumnOrder(5);

        builder.Property(u => u.Address)
               .IsRequired()
               .HasMaxLength(255)
               .HasColumnOrder(6);

        builder.Property(u => u.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnOrder(7);

        builder.ToTable("User");
    }
}
