namespace Ordering.Application.Orders.EventHandlers.Domain;

using Ordering.Domain.Events;
using Microsoft.Extensions.Logging;
using MassTransit;
using Microsoft.FeatureManagement;

public class OrderCreatedEventHandler(
    IPublishEndpoint publishEndpoint,
    IFeatureManager featureManager,
    ILogger<OrderCreatedEventHandler> logger)
    : INotificationHandler<OrderCreatedEvent>
{
    public async Task Handle(
        OrderCreatedEvent domainEvent, CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "Domain Event handled: {Event}",
            domainEvent.GetType().Name);

        if (await featureManager.IsEnabledAsync("OrderFulfillment"))
        {
            var orderCreatedIntegrationEvent = domainEvent.Order.ToDto();

            await publishEndpoint.Publish(orderCreatedIntegrationEvent, cancellationToken);
        }
    }
}
