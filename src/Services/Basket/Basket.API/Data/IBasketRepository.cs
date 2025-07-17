namespace Basket.API.Data;

using Entities;

public interface IBasketRepository
{
    Task<ShoppingCart?> GetBasketAsync(
        string username, CancellationToken cancellationToken = default);
    
    Task<ShoppingCart> StoreBasketAsync(
        ShoppingCart shoppingCart, CancellationToken cancellationToken = default);
    
    Task<bool> DeleteBasketAsync(
        string username, CancellationToken cancellationToken = default);
}