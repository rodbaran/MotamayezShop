
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Mt.Shop.Application;

public static class ConfigureService
{
    public static void AddApplicationServices(this IServiceCollection services)
    {

        //CQRS = Mediator
        //collection add => service provider get =>DI
        //services.AddMediatR(Assembly.GetExecutingAssembly());

    }
}