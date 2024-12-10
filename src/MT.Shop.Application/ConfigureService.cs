
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Mt.Shop.Application;

public static class ConfigureService
{
    public static void AddApplicationServices(this IServiceCollection services)
    {

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}