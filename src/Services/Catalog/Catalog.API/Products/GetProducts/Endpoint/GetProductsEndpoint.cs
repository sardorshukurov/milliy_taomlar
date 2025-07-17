
namespace Catalog.API.Products.GetProducts.Endpoint;

using Catalog.API.Products.GetProducts.Handler;
using Dtos;

public class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products/paged",
            async (PagedRequest<GetProductsFilter>? request, ISender sender) =>
            {
                var query = new GetProductsQuery(request);

                var result = await sender.Send(query);

                return result.ToResult(res => Results.Ok(res));
            })
            .WithName("GetProducts")
            .Produces<Response<PagedResponse<ProductDto>>>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Products")
            .WithDescription("Get Products");
    }
}
