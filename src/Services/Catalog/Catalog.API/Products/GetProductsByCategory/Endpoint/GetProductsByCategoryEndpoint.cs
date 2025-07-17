namespace Catalog.API.Products.GetProductsByCategory.Endpoint;

public class GetProductsByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{category}",
            async (string category, ISender sender) =>
            {
                var request = new GetProductsByCategoryRequest(category);
                var response = (await sender.Send(request.ToQuery())).ToResponse();

                return response.ToResult(res => Results.Ok(res));
            })
            .WithName("GetProductByCategory")
            .Produces<GetProductsByCategoryResponse>()
            .Produces(StatusCodes.Status400BadRequest)
            .WithSummary("Get Products By Category")
            .WithDescription("Get Products By Category");
    }
}
