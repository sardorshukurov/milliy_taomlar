namespace Basket.API.Data;

using Entities;

public class BasketRepository(IDocumentSession session)
    : IBasketRepository
{
    public async Task<ShoppingCart?> GetBasketAsync(
        string username, CancellationToken cancellationToken = default)
    {
        var basket = await session.LoadAsync<ShoppingCart>(username, cancellationToken);

        return basket;
    }

    public async Task<ShoppingCart> StoreBasketAsync(
        ShoppingCart shoppingCart, CancellationToken cancellationToken = default)
    {
        session.Store(shoppingCart);
        
        await session.SaveChangesAsync(cancellationToken);

        return shoppingCart;
    }

    public async Task<bool> DeleteBasketAsync(
        string username, CancellationToken cancellationToken = default)
    {
        session.Delete<ShoppingCart>(username);
        await session.SaveChangesAsync(cancellationToken);
        return true;
    }
}