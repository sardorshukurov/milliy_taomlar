namespace Basket.API.Baskets.StoreBasket.Handler;

public record StoreBasketCommand(StoreShoppingCartDto Cart) : ICommand<StoreBasketResult>;