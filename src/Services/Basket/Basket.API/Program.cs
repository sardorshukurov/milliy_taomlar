using Basket.API.Data;
using Basket.API.Entities;
using FluentValidation;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Shared.Behaviors;
using Shared.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var connectionString =
    builder.Configuration.GetConnectionString("Database") ?? string.Empty;

builder.Services
    .AddExceptionHandler<GlobalExceptionHandler>()
    .AddCarter()
    .AddMediatR(configuration =>
    {
        configuration.RegisterServicesFromAssembly(typeof(Program).Assembly);
        configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
        configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
    })
    .AddValidatorsFromAssembly(typeof(Program).Assembly)
    .AddMarten(options =>
    {
        options.Connection(connectionString);
        options.Schema.For<ShoppingCart>().Identity(sc => sc.Username);
    }).UseLightweightSessions();

builder.Services.AddHealthChecks().AddNpgSql(connectionString);

builder.Services.AddScoped<IBasketRepository, BasketRepository>();

var app = builder.Build();

app.UseExceptionHandler(_ => { });

app.MapCarter();

app.UseHealthChecks("/health",
    new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
    });

app.Run();
