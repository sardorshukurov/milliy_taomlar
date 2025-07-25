namespace Shared.Messaging.MassTransit;

using System.Reflection;
using global::MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class Extensions
{
    public static IServiceCollection AddMessageBroker(
        this IServiceCollection services, IConfiguration configuration, Assembly? assembly = null)
    {
        services.AddMassTransit(c =>
        {
            c.SetKebabCaseEndpointNameFormatter();

            if (assembly is not null)
            {
                c.AddConsumers(assembly);
            }

            c.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host(
                    new Uri(configuration["MessageBroker:Host"] ?? string.Empty), host =>
                {
                    host.Username(configuration["MessageBroker:Username"] ?? string.Empty);
                    host.Password(configuration["MessageBroker:Password"] ?? string.Empty);
                });

                configurator.ConfigureEndpoints(context);
            });
        });

        return services;
    }
}