namespace Ordering.Application.Orders.EventHandlers;

using Domain.Events;
using Microsoft.Extensions.Logging;

public class OrderCreatedEventHandler(ILogger<OrderCreatedEventHandler> logger)
    : INotificationHandler<OrderCreatedEvent>
{
    public Task Handle(
        OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "Domain Event handled: {Event}",
            notification.GetType().Name);

        return Task.CompletedTask;
    }
}
