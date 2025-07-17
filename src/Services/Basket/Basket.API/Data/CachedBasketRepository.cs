namespace Basket.API.Data;

using Entities;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

public class CachedBasketRepository(
    IBasketRepository baseRepository, IDistributedCache cache)
    : IBasketRepository
{
    public async Task<ShoppingCart?> GetBasketAsync(
        string username, CancellationToken cancellationToken = default)
    {
        var cachedBasket = await cache.GetStringAsync(
            username, cancellationToken);
        
        if (!string.IsNullOrEmpty(cachedBasket))
        {
            return JsonSerializer.Deserialize<ShoppingCart?>(cachedBasket);
        }
        
        var basket = await baseRepository.GetBasketAsync(
            username, cancellationToken);
        await cache.SetStringAsync(
            username, JsonSerializer.Serialize(basket), cancellationToken);
        
        return basket;
    }

    public async Task<ShoppingCart> StoreBasketAsync(
        ShoppingCart shoppingCart, CancellationToken cancellationToken = default)
    {
        await baseRepository.StoreBasketAsync(shoppingCart, cancellationToken);

        await cache.SetStringAsync(
            shoppingCart.Username, JsonSerializer.Serialize(shoppingCart), cancellationToken);

        return shoppingCart;
    }

    public async Task<bool> DeleteBasketAsync(
        string username, CancellationToken cancellationToken = default)
    {
        await baseRepository.DeleteBasketAsync(username, cancellationToken);
        
        await cache.RemoveAsync(username, cancellationToken);
        
        return true;
    }
}