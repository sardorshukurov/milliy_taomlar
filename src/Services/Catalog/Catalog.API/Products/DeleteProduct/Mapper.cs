namespace Catalog.API.Products.DeleteProduct;

using Endpoint;
using Handler;

public static class Mapper
{
    public static DeleteProductResponse ToResponse(this DeleteProductResult result)
    {
        return new DeleteProductResponse(result.IsSuccess);
    }
}