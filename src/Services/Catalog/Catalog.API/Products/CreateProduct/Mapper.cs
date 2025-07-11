namespace Catalog.API.Products.CreateProduct;

using Entities;
using Endpoint;
using Handler;

public static class Mapper
{
    public static CreateProductCommand ToCommand(this CreateProductRequest request)
    {
        return new(
            request.Name,
            request.Categories,
            request.Description,
            request.ImageFile,
            request.Price);
    }

    public static Response<CreateProductResponse> ToResponse(this Response<CreateProductResult> result)
    {
        return new(
            result.IsSuccess,
            result.StatusCode,
            result.Result is null
                ? null
                : new(result.Result.Id));
    }

    public static Product ToEntity(this CreateProductCommand command)
    {
        return new Product
        {
            Name = command.Name,
            Categories = command.Categories,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price,
        };
    }
}
