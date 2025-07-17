namespace Basket.API.Baskets.GetBasket.Handler;

using Data;

public class GetBasketHandler(IBasketRepository repository)
    : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public async Task<Response<GetBasketResult>> Handle(
        GetBasketQuery query, CancellationToken cancellationToken)
    {
        var basket = await repository.GetBasketAsync(
            query.Username,cancellationToken);

        if (basket is null)
        {
            return new Response<GetBasketResult>(
                false,
                StatusCodes.Status404NotFound,
                null,
                $"Basket for user '{query.Username}' not found.");
        }
        
        return new Response<GetBasketResult>(
            true,
            StatusCodes.Status200OK,
            new GetBasketResult(basket.ToDto()));
    }
}
