using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MT.Shop.Domain.Orders;

namespace MT.Shop.Infrastructure.EntityConfigurations.Orders;

public class OrderDetailEntityTypeConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.HasKey(od => od.Id);

        builder.Property(od => od.Quantity)
               .IsRequired();

        builder.Property(od => od.UnitPrice)
               .HasColumnType("decimal(18,2)")
               .IsRequired();

        builder.HasOne(od => od.Product)
               .WithMany()
               .HasForeignKey(od => od.ProductId)
               .OnDelete(DeleteBehavior.Restrict);



        builder.ToTable("OrderDetails");
    }
}
