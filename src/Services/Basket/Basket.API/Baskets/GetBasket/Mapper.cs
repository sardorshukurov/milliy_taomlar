namespace Basket.API.Baskets.GetBasket;

using Endpoint;
using Handler;
using Entities;

public static class Mapper
{
    public static Response<GetBasketResponse> ToResponse(this Response<GetBasketResult> result) =>
        new(
            result.IsSuccess,
            result.StatusCode,
            new(result.Result?.Cart),
            result.ErrorMessage,
            result.ErrorDetails);
    
    public static ShoppingCartDto ToDto(this ShoppingCart entity)
    {
        return new ShoppingCartDto(
            entity.Username,
            entity.Items.Select(i => i.ToDto()).ToList(),
            entity.TotalPrice);
    }
    
    private static ShoppingCartItemDto ToDto(this ShoppingCartItem entity)
    {
        return new ShoppingCartItemDto(
            entity.ProductId,
            entity.ProductName,
            entity.Quantity,
            entity.Size,
            entity.Price);
    }
}
