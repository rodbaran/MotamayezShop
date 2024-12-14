using Mt.Shop.Application;
using MT.Shop.Infrastructure;
using MT.Shop.Api.Middleware;
using MT.Shop.Api;

var builder = WebApplication.CreateBuilder(args);

//configuration
builder.Services.AddApplicationServices();

builder.Services.AddInfrastructureService(builder.Configuration);

builder.AddApiConfigureServices(builder.Configuration);
//build
var app = builder.Build();

app.UseMiddleware< MiddlewareExceptionHandler >();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Test1 Api v1");
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
