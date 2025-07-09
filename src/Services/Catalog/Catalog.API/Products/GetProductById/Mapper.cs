namespace Catalog.API.Products.GetProductById;

using Catalog.API.Products.GetProductById.Endpoint;
using Catalog.API.Products.GetProductById.Handler;

public static class Mapper
{
    public static GetProductByIdQuery ToQuery(this GetProductByIdRequest request)
    {
        return new GetProductByIdQuery(request.Id);
    }
}
