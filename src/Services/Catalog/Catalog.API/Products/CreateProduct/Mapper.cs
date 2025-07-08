namespace Catalog.API.Products.CreateProduct;

using Catalog.API.Products.CreateProduct.Endpoint;
using Catalog.API.Products.CreateProduct.Handler;

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

    public static CreateProductResponse ToResponse(this CreateProductResult result)
    {
        return new(result.Id);
    }
}
