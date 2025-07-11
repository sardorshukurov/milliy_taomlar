using FluentValidation;
using Shared.Behaviors;
using Shared.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Register services.
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
        options.Connection(builder.Configuration.GetConnectionString("Database") ?? string.Empty);
    }).UseLightweightSessions();

var app = builder.Build();

app.UseExceptionHandler(_ => { });

app.MapCarter();

app.Run();
