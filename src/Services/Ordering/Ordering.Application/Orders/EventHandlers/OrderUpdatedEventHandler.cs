namespace Ordering.Application.Orders.EventHandlers;

using Domain.Events;
using Microsoft.Extensions.Logging;

public class OrderUpdatedEventHandler(ILogger<OrderUpdatedEventHandler> logger)
    : INotificationHandler<OrderUpdatedEvent>
{
    public Task Handle(
        OrderUpdatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "Domain Event handled: {Event}",
            notification.GetType().Name);

        return Task.CompletedTask;
    }
}
