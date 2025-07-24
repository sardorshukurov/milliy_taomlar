
namespace Ordering.API.Endpoints.UpdateOrder;

public class UpdateOrderEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/orders", async (UpdateOrderRequest request, ISender sender) =>
        {
            var command = request.ToCommand();
            var result = await sender.Send(command);

            return result.ToResult(res => Results.Ok(res));
        })
        .WithName("UpdateOrder")
        .Produces<Response<Unit>>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Update Order")
        .WithDescription("Update Order");
    }
}
