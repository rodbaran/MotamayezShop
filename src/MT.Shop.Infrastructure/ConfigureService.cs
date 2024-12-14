using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MT.Shop.Application.Contracts;
using MT.Shop.Domain.Entities.Orders;
using MT.Shop.Domain.Entities.Products;
using MT.Shop.Domain.Entities.Users;
using MT.Shop.Infrastructure.DataService.Orders;
using MT.Shop.Infrastructure.DataService.Products;
using MT.Shop.Infrastructure.DataService.Users;
using MT.Shop.Infrastructure.DBContext;
using MT.Shop.Infrastructure.UnitOfWorks;


namespace MT.Shop.Infrastructure;

public static class ConfigureService
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection services , IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(option =>
        {
            option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        // services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IUserService , UserService>();
        services.AddScoped<IProductService, ProductService>();

        return services;
    }
}
