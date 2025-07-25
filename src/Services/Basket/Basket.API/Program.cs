using Basket.API.Data;
using Basket.API.Entities;
using Discount.Grpc;
using FluentValidation;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Shared.Behaviors;
using Shared.Middlewares;
using Shared.Messaging.MassTransit;

var builder = WebApplication.CreateBuilder(args);
var database =
    builder.Configuration.GetConnectionString("Database") ?? string.Empty;
var redis =
    builder.Configuration.GetConnectionString("Redis") ?? string.Empty;
var discountUrl =
    builder.Configuration["GrpcSettings:DiscountUrl"] ?? string.Empty;

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
        options.Connection(database);
        options.Schema.For<ShoppingCart>().Identity(sc => sc.Username);
    }).UseLightweightSessions();

builder.Services.AddHealthChecks()
    .AddNpgSql(database)
    .AddRedis(redis);

builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.Decorate<IBasketRepository, CachedBasketRepository>();

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = redis;
});

builder.Services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(options =>
{
    options.Address = new Uri(discountUrl);
});

builder.Services.AddMessageBroker(builder.Configuration);

var app = builder.Build();

app.UseExceptionHandler(_ => { });

app.MapCarter();

app.UseHealthChecks("/health",
    new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
    });

app.Run();
