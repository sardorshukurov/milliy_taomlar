namespace Catalog.API.Products.UpdateProduct.Endpoint;

public class UpdateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/products", async (UpdateProductRequest request, ISender sender) =>
        {
            var command = request.ToCommand();
            var result = await sender.Send(command);
            var response = result.ToResponse();

            return response.IsSuccess
                ? Results.Ok(response)
                : Results.BadRequest(response);
        })
        .WithName("UpdateProduct")
        .Produces<UpdateProductResponse>()
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Product")
        .WithDescription("Update Product");
    }
}