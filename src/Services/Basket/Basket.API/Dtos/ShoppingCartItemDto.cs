namespace Basket.API.Dtos;

public record ShoppingCartItemDto(
    Guid ProductId,
    string ProductName,
    int Quantity,
    float Size,
    decimal Price);
