
namespace Catalog.API.Products.GetProductById.Endpoint;

public class GetProductByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
        {
            var request = new GetProductByIdRequest(id);
            var result = await sender.Send(request.ToQuery());

            if (result.Product is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result.Product);
        })
        .WithName("GetProductById")
        .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Product By Id")
        .WithDescription("Get Product By Id");
    }
}
