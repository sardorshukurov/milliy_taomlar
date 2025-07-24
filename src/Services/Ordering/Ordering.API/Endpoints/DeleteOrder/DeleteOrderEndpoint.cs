namespace Ordering.API.Endpoints.DeleteOrder;

using Application.Orders.Commands.DeleteOrder;

public class DeleteOrderEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/orders/{id}", async (Guid id, ISender sender) =>
        {
            var command = new DeleteOrderCommand(id);
            var result = await sender.Send(command);

            return result.ToResult(res => Results.Ok(res));
        })
        .WithName("DeleteOrder")
        .Produces<Response<Unit>>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete Order")
        .WithDescription("Delete Order");
    }
}
