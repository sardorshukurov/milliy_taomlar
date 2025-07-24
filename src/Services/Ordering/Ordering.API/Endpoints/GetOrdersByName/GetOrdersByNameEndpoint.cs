namespace Ordering.API.Endpoints.GetOrdersByName;

using Application.Orders.Queries.GetOrdersByName;

public class GetOrdersByNameEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders/{name}", async (string name, ISender sender) =>
        {
            var query = new GetOrdersByNameQuery(name);
            var result = await sender.Send(query);
            var response = result.ToResponse();

            return response.ToResult(res => Results.Ok(res));
        })
        .WithName("GetOrdersByName")
        .Produces<Response<GetOrdersByNameResponse>>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Orders By Name")
        .WithDescription("Get Orders By Name");
    }
}

