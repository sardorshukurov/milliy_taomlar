namespace Ordering.API.Endpoints.CreateOrder;

public class CreateOrderEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/orders", async (CreateOrderRequest request, ISender sender) =>
        {
            var command = request.ToCommand();
            var result = await sender.Send(command);
            var response = result.ToResponse();

            return response.ToResult(
                res => Results.Created($"/orders/{res.Result!.OrderId}", res));
        })
        .WithName("CreateOrder")
        .Produces<Response<CreateOrderResponse>>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Order")
        .WithDescription("Create Order");
    }
}
