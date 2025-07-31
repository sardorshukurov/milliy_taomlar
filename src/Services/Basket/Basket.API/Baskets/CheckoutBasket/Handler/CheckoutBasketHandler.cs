namespace Basket.API.Baskets.CheckoutBasket.Handler;

using Data;
using Shared.Models;

public class CheckoutBasketHandler(
    IBasketRepository repository,
    MassTransit.IPublishEndpoint publishEndpoint)
    : ICommandHandler<CheckoutBasketCommand>
{
    public async Task<Response<Unit>> Handle(
        CheckoutBasketCommand command, CancellationToken cancellationToken)
    {
        var basket = await repository.GetBasketAsync(command.Basket.Username, cancellationToken);
        if (basket is null)
        {
            return new Response<Unit>(
                false,
                StatusCodes.Status404NotFound,
                Unit.Value,
                "Basket not found");
        }

        var eventMessage = command.Basket.ToEvent();

        await publishEndpoint.Publish(eventMessage, cancellationToken);

        await repository.DeleteBasketAsync(command.Basket.Username, cancellationToken);

        return new Response<Unit>(
            true,
            StatusCodes.Status200OK,
            Unit.Value);
    }
}
