using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MT.Shop.Domain.Entities.Orders;

namespace MT.Shop.Infrastructure.EntityConfigurations.Orders;

public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Status)
               .HasConversion<string>()
               .IsRequired()
               .HasColumnOrder(3);

        builder.HasMany(o => o.OrderDetails)
               .WithOne()
               .HasForeignKey(od => od.OrderId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("Order");
    }
}
