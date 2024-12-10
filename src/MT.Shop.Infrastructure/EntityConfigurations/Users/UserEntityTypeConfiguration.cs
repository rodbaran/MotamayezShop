using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MT.Shop.Domain.Users;

namespace MT.Shop.Infrastructure.EntityConfigurations.Users;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {

        builder.HasKey(u => u.Id);

        builder.Property(u => u.FirstName)
               .IsRequired()
               .HasMaxLength(60);

        builder.Property(u => u.LastName)
               .IsRequired()
               .HasMaxLength(60);

        builder.Property(u => u.Email)
               .IsRequired()
               .HasMaxLength(60);

        builder.Property(u => u.Address)
               .IsRequired()
               .HasMaxLength(255);

        builder.Property(u => u.CreatedOn)
               .IsRequired();

        builder.Property(u => u.ModifiedOn)
               .IsRequired(false);

        builder.Property(u => u.VersionCtrl)
               .IsRowVersion();

        builder.ToTable("Users");
    }
}
