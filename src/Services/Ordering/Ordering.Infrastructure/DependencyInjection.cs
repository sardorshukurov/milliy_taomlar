namespace Ordering.Infrastructure;

using Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices
        (this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database")
            ?? string.Empty;

        services.AddDbContext<OrderingDbContext>(options =>
            options.UseSqlServer(connectionString));

        return services;
    }
}
