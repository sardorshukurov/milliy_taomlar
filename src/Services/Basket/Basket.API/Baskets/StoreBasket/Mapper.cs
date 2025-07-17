namespace Basket.API.Baskets.StoreBasket;

using Entities;
using Endpoint;
using Handler;

public static class Mapper
{
    public static Response<StoreBasketResponse> ToResponse(this Response<StoreBasketResult> result) =>
        new(
            result.IsSuccess,
            result.StatusCode,
            new StoreBasketResponse(result.Result?.Username ?? string.Empty),
            result.ErrorMessage,
            result.ErrorDetails);
    
    public static ShoppingCart ToEntity(this StoreShoppingCartDto dto)
    {
        return new ShoppingCart
        {
            Username = dto.Username,
            Items = dto.Items.Select(i => i.ToEntity()).ToList(),
        };
    }
    
    private static ShoppingCartItem ToEntity(this ShoppingCartItemDto dto)
    {
        return new ShoppingCartItem
        {
            ProductId = dto.ProductId,
            ProductName = dto.ProductName,
            Quantity = dto.Quantity,
            Size = dto.Size,
            Price = dto.Price
        };
    }
}