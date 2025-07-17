namespace Basket.API.Baskets.StoreBasket.Handler;

using Data;

public class StoreBasketHandler(IBasketRepository repository)
    : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<Response<StoreBasketResult>> Handle(
        StoreBasketCommand command, CancellationToken cancellationToken)
    {
        var shoppingCart = command.Cart.ToEntity();

        await repository.StoreBasketAsync(shoppingCart, cancellationToken);
        
        return new Response<StoreBasketResult>(
            true,
            StatusCodes.Status200OK,
            new StoreBasketResult(command.Cart.Username));
    }
}
