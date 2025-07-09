
namespace Catalog.API.Products.GetProductsByCategory.Endpoint;

public class GetProductsByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{category}",
            async (string category, ISender sender) =>
            {
                var request = new GetProductsByCategoryRequest(category);
                var result = await sender.Send(request.ToQuery());
                var response = result.ToResponse();

                return Results.Ok(response);
            })
            .WithName("GetProductByCategory")
            .Produces<GetProductsByCategoryResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithSummary("Get Products By Category")
            .WithDescription("Get Products By Category");
    }
}
