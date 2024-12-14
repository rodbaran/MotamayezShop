using Serilog;

namespace MT.Shop.Api;

public static class ConfigureService
{
    public static IServiceCollection AddApiConfigureServices(this WebApplicationBuilder builder,  IConfiguration configuration)
    {
        // Add services to the container.

        builder.Services.AddControllers();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();


        builder.Services.AddSwaggerGen();

        // for catch
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddDistributedMemoryCache();

        // پیکربندی لاگ فایل
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day) // ذخیره لاگ‌ها به صورت روزانه
            .CreateLogger();

        builder.Logging.ClearProviders(); // حذف لاگرهای پیش‌فرض
        builder.Logging.AddSerilog();

        return builder.Services;
    }
}
