namespace Basket.API.Dtos;

public record StoreShoppingCartDto(
    string Username,
    IList<ShoppingCartItemDto> Items);
