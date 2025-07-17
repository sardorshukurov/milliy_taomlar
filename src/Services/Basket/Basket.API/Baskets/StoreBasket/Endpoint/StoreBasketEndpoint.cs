namespace Basket.API.Baskets.StoreBasket.Endpoint;

using Handler;

public class StoreBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket", async (
            StoreBasketRequest request,
            ISender sender) =>
        {
            var result = await sender.Send(new StoreBasketCommand(request.Cart));
            var response = result.ToResponse();

            return response.ToResult(res => Results.Created($"/basket/{res.Result!.Username}", res));
        })
        .WithName("StoreBasket")
        .Produces<Response<StoreBasketResponse>>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Store Basket")
        .WithDescription("Store Basket");
    }
}
