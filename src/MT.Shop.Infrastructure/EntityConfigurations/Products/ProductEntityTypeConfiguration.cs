using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MT.Shop.Domain.Products;

namespace MT.Shop.Infrastructure.EntityConfigurations.Products;

public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(p => p.Code)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(p => p.Price)
               .HasColumnType("decimal(18,2)");

        builder.Property(p => p.AvailableStock)
               .IsRequired();


        builder.ToTable("Products");
    }
}
