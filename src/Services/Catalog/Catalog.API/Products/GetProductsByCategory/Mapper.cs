namespace Catalog.API.Products.GetProductsByCategory;

using Catalog.API.Products.GetProductsByCategory.Endpoint;
using Catalog.API.Products.GetProductsByCategory.Handler;

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
