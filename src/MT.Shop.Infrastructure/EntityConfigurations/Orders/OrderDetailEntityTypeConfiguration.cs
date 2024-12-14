using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MT.Shop.Domain.Entities.Orders;

namespace MT.Shop.Infrastructure.EntityConfigurations.Orders;

public class OrderDetailEntityTypeConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.HasKey(od => od.Id);

        builder.Property(od => od.Quantity)
               .IsRequired()
               .HasColumnOrder(3);

        builder.Property(od => od.UnitPrice)
               .HasColumnType("decimal(18,2)")
               .IsRequired()
               .HasColumnOrder(4);


        builder.Property(od => od.OrderId)
               .HasColumnOrder(5);

        builder.Property(od => od.ProductId)
                .HasColumnOrder(6);

        builder.HasOne(od => od.Product)
               .WithMany()
               .HasForeignKey(od => od.ProductId)
               .OnDelete(DeleteBehavior.Restrict);



        builder.ToTable("OrderDetail");
    }
}
