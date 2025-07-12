
using Catalog.API.Products.Dtos;
using Catalog.API.Products.GetProducts.Handler;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Products.GetProducts.Endpoint;

public class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products/paged",
            async (PagedRequest<GetProductsFilter>? request, ISender sender) =>
            {
                var query = new GetProductsQuery(request);

                var result = await sender.Send(query);

                return Results.Ok(result);
            })
            .WithName("GetProducts")
            .Produces<PagedResponse<ProductDto>>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Products")
            .WithDescription("Get Products");
    }
}
