using Microsoft.EntityFrameworkCore;
using MT.Shop.Infrastructure.DBContext;

namespace MT.Shop.Api;

public static class ConfigureService
{
    public static  IServiceCollection AddApiServiceCollection(this WebApplicationBuilder builder)
    {

        return builder.Services;
    }
}
