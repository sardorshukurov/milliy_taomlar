namespace Basket.API.Baskets.DeleteBasket.Handler;

public record DeleteBasketCommand(string Username) : ICommand;
