namespace Ordering.Application.Orders.EventHandlers.Integration;

using Commands.CreateOrder;
using Dtos;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Messaging.Events;
using Ordering.Domain.Enums;

public class BasketCheckoutEventHandler(
    ISender sender, ILogger<BasketCheckoutEventHandler> logger)
    : IConsumer<BasketCheckoutEvent>
{
    public async Task Consume(
        ConsumeContext<BasketCheckoutEvent> context)
    {
        logger.LogInformation("Integration Event received: {Event}", context.Message.GetType().Name);

        var address = new AddressDto(
            context.Message.FirstName,
            context.Message.LastName,
            context.Message.Email,
            context.Message.AddressLine,
            context.Message.Country,
            context.Message.State,
            context.Message.ZipCode
        );

        var payment = new PaymentDto(
            context.Message.CardNumber,
            context.Message.CardHolderName,
            context.Message.CardExpiration,
            context.Message.CardSecurityCode,
            context.Message.PaymentMethod
        );

        var command = new CreateOrderCommand
        (
            context.Message.CustomerId,
            context.Message.FirstName,
            address,
            address,
            payment,
            OrderStatus.Pending,
            []
        );

        await sender.Send(command, context.CancellationToken);
    }
}
