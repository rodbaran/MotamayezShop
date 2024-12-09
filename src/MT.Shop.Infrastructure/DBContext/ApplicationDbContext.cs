using Microsoft.EntityFrameworkCore;
using MT.Shop.Domain.BaseInfo;
using MT.Shop.Domain.Orders;
using MT.Shop.Domain.Products;
using System.Reflection;

namespace MT.Shop.Infrastructure.DBContext;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Product> Products { get; set; }




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        //modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
    }
}


