var builder = WebApplication.CreateBuilder(args);

// Register services.
builder.Services
    .AddCarter()
    .AddMediatR(configuration =>
    {
        configuration.RegisterServicesFromAssembly(typeof(Program).Assembly);
    });

var app = builder.Build();

app.MapCarter();

app.Run();
