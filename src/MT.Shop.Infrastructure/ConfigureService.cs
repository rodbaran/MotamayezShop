using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MT.Shop.Domain.Helper;
using MT.Shop.Infrastructure.DBContext;
using MT.Shop.Infrastructure.Helper;
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
        return services;
    }
}
