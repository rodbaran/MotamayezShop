using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MT.Shop.Domain.Entities.Orders;
using MT.Shop.Domain.Entities.Products;
using MT.Shop.Domain.Entities.Users;
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

        modelBuilder.Entity<User>().HasQueryFilter(x => x.IsDelete == false);
        modelBuilder.Entity<Order>().HasQueryFilter(x => x.IsDelete == false);
        modelBuilder.Entity<OrderDetail>().HasQueryFilter(x => x.IsDelete == false);
        modelBuilder.Entity<Product>().HasQueryFilter(x => x.IsDelete == false);

        modelBuilder.Entity<User>()
            .HasData(
                    new User(1, "حسین", "رودباران", "09120753301", "rodbaran@Gmail.com", "Tehran")
            );


        var random = new Random();
        var products = new List<Product>();

        for (int i = 1; i <= 100; i++)
        {
            // تولید قیمت رندوم بین 200,000 تا 100,000,000 رند به 10,000
            var price = random.Next(20, 10001) * 10000; // عدد بین 20 تا 10,000 و ضرب در 10,000

            // تولید تعداد رندوم بین 0 تا 128
            var stock = random.Next(0, 129);

            products.Add(new Product(i, $"1000{i:D4}", $"کالای {i}", price, stock));
        }

        modelBuilder.Entity<Product>().HasData(products);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }




}


