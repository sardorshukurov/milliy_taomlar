namespace Basket.API.Baskets.GetBasket.Endpoint;

using Handler;

public class GetBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{username}", async (
            string username,
            ISender sender) =>
        {
            var result = await sender.Send(new GetBasketQuery(username));

            var response = result.ToResponse();

            return response.ToResult(res => Results.Ok(res));
        })
        .WithName("GetBasket")
        .Produces<Response<GetBasketResponse>>()
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Basket")
        .WithDescription("Get Basket");
    }
}
