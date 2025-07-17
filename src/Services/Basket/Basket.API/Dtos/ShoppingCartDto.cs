namespace Basket.API.Dtos;

public record ShoppingCartDto(
    string Username,
    IList<ShoppingCartItemDto> Items,
    decimal TotalPrice);
