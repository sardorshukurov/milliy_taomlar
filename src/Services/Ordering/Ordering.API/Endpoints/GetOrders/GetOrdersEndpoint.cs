namespace Ordering.API.Endpoints.GetOrders;

using Application.Orders.Queries.GetOrders;
using Ordering.Application.Dtos;

public class GetOrdersEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/orders/paged",
            async (PagedRequest<GetOrdersFilter>? request, ISender sender) =>
            {
                var query = new GetOrdersQuery(request);
                var result = await sender.Send(query);

                return result.ToResult(res => Results.Ok(res));
            })
            .WithName("GetOrders")
            .Produces<Response<PagedResponse<OrderDto>>>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Orders")
            .WithDescription("Get Orders");
    }
}

