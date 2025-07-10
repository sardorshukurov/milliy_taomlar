namespace Catalog.API.Products.GetProductById;

using Endpoint;
using Handler;

public static class Mapper
{
    public static GetProductByIdResponse ToResponse(
        this GetProductByIdResult result)
    {
        return new GetProductByIdResponse(result.Product);
    }
}
