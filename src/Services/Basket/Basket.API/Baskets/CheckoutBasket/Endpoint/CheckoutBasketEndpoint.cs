
namespace Basket.API.Baskets.CheckoutBasket.Endpoint;

using Handler;

public class CheckoutBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket/checkout", async (CheckoutBasketRequest request, ISender sender) =>
        {
            var command = new CheckoutBasketCommand(request.Basket);
            var result = await sender.Send(command);
            return result.ToResult(res => Results.Ok(res));
        })
        .WithName("CheckoutBasket")
        .Produces<Response<Unit>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status500InternalServerError)
        .WithSummary("Checkout a basket")
        .WithDescription("Checkout a basket");
    }
}
