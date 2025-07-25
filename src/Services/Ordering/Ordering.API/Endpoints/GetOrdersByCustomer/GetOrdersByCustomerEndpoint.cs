
using Ordering.Application.Orders.Queries.GetOrdersByCustomer;

namespace Ordering.API.Endpoints.GetOrdersByCustomer;

public class GetOrdersByCustomerEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders/by-customer/{customerId}", async (Guid customerId, ISender sender) =>
        {
            var query = new GetOrdersByCustomerQuery(customerId);
            var result = await sender.Send(query);
            var response = result.ToResponse();

            return response.ToResult(res => Results.Ok(res));
        })
        .WithName("GetOrdersByCustomer")
        .Produces<Response<GetOrdersByCustomerResponse>>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Orders By Customer")
        .WithDescription("Get Orders By Customer");
    }
}
