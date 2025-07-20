namespace Basket.API.Baskets.StoreBasket.Handler;

using Entities;
using Data;
using Discount.Grpc;

public class StoreBasketHandler(
    IBasketRepository repository, DiscountProtoService.DiscountProtoServiceClient discountProto)
    : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<Response<StoreBasketResult>> Handle(
        StoreBasketCommand command, CancellationToken cancellationToken)
    {
        var shoppingCart = command.Cart.ToEntity();

        await DeductDiscountAsync(shoppingCart, cancellationToken);

        await repository.StoreBasketAsync(shoppingCart, cancellationToken);
        
        return new Response<StoreBasketResult>(
            true,
            StatusCodes.Status200OK,
            new StoreBasketResult(command.Cart.Username));
    }

    private async Task DeductDiscountAsync(ShoppingCart cart, CancellationToken cancellationToken)
    {
        foreach (var item in cart.Items)
        {
            var coupon = await discountProto.GetDiscountAsync(
                new GetDiscountRequest { ProductName = item.ProductName },
                cancellationToken: cancellationToken);
            item.Price -= coupon.Amount;
        }
    }
}
