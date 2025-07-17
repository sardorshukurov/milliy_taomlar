namespace Basket.API.Baskets.GetBasket.Handler;

public record GetBasketQuery(string Username)
    : IQuery<GetBasketResult>;
