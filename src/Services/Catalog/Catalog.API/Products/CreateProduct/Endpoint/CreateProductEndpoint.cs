namespace Catalog.API.Products.CreateProduct.Endpoint;

public class CreateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products",
            async (CreateProductRequest request, ISender sender) =>
        {
            var command = request.ToCommand();

            var result = await sender.Send(command);

            if (result.IsSuccess is false || result.Result is null)
            {
                return Results.BadRequest(result);
            }

            var response = result.ToResponse();

            return Results.Created($"/products/{response.Result!.Id}", response);
        })
        .WithName("CreateProduct")
        .Produces<Response<CreateProductResponse>>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Product")
        .WithDescription("Create Product");
    }
}
