using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using MT.Shop.Application.Common.BehavioursPipes;

namespace Mt.Shop.Application;

public static class ConfigureService
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        // CQRS
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        //Validator
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        //pipeline
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachedQueryBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
    }
}