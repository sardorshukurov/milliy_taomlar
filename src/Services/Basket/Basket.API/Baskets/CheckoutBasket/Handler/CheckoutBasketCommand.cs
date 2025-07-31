namespace Basket.API.Baskets.CheckoutBasket.Handler;

public record CheckoutBasketCommand(BasketCheckoutDto Basket) : ICommand;
