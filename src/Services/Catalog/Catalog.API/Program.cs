var builder = WebApplication.CreateBuilder(args);

// Register services.
builder.Services
    .AddCarter()
    .AddMediatR(configuration =>
    {
        configuration.RegisterServicesFromAssembly(typeof(Program).Assembly);
    })
    .AddMarten(options =>
    {
        options.Connection(builder.Configuration.GetConnectionString("Database") ?? string.Empty);
    }).UseLightweightSessions();

var app = builder.Build();

app.MapCarter();

app.Run();
