namespace Catalog.API.Products.CreateProduct.Endpoint;

public class CreateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products",
            async (CreateProductRequest request, ISender sender) =>
        {
            var command = request.ToCommand();

            var response = (await sender.Send(command)).ToResponse();

            return response.ToResult(
                res => Results.Created($"/products/{res.Result!.Id}", res));
        })
        .WithName("CreateProduct")
        .Produces<Response<CreateProductResponse>>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Product")
        .WithDescription("Create Product");
    }
}
