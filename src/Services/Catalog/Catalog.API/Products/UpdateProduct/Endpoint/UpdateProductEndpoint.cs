namespace Catalog.API.Products.UpdateProduct.Endpoint;

public class UpdateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/products", async (UpdateProductRequest request, ISender sender) =>
        {
            var command = request.ToCommand();
            var result = await sender.Send(command);

            return result.ToResult(res => Results.Ok(res));
        })
        .WithName("UpdateProduct")
        .Produces<Response<Unit>>()
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Update Product")
        .WithDescription("Update Product");
    }
}