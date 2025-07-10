namespace Catalog.API.Products.GetProductsByCategory;

using Endpoint;
using Handler;

public static class Mapper
{
    public static GetProductsByCategoryQuery ToQuery(this GetProductsByCategoryRequest request)
    {
        return new GetProductsByCategoryQuery(request.Category);
    }

    public static GetProductsByCategoryResponse ToResponse(this GetProductsByCategoryResult result)
    {
        return new GetProductsByCategoryResponse(result.Products);
    }
}
