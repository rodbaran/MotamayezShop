using Mt.Shop.Application;
using MT.Shop.Infrastructure;
using MT.Shop.Api.Middleware;
using Microsoft.AspNetCore.Mvc;
using MT.Shop.Domain.Exceptions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = actionContext =>
    {
        var errors = actionContext.ModelState
            .Where(e => e.Value != null && e.Value.Errors.Count > 0)
            .SelectMany(v => v.Value!.Errors)
            .Select(c => c.ErrorMessage).ToList();

        return new BadRequestObjectResult(new ApiToReturn(400, errors));
    };
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//configuration
builder.Services.AddApplicationServices();

builder.Services.AddInfrastructureService(builder.Configuration);

builder.Services.AddSwaggerGen();
var app = builder.Build();

app.UseMiddleware< MiddlewareExceptionHandler >();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Test1 Api v1");
});

app.Run();
