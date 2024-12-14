using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MT.Shop.Domain.Entities.Products;

namespace MT.Shop.Infrastructure.EntityConfigurations.Products;

public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Price)
               .HasColumnType("decimal(18,2)")
               .HasColumnOrder(3);

        builder.Property(p => p.AvailableStock)
               .IsRequired()
               .HasColumnOrder(4);


        builder.ToTable("Product");
    }
}
