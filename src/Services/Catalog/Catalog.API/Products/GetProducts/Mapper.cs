namespace Catalog.API.Products.GetProducts;

using Catalog.API.Entities;
using Catalog.API.Products.GetProducts.Dtos;
using Catalog.API.Products.GetProducts.Endpoint;
using Catalog.API.Products.GetProducts.Handler;

public static class Mapper
{
    public static GetProductsQuery ToQuery(this GetProductsRequest request)
    {
        return new GetProductsQuery(
            request.Name ?? string.Empty,
            request.Categories ?? [],
            request.MinimumPrice,
            request.MaximumPrice
        );
    }

    public static GetProductsResponse ToResponse(this GetProductsResult result)
    {
        return new GetProductsResponse(result.Products);
    }

    public static ProductDto ToDto(this Product entity)
    {
        return new ProductDto(
            entity.Id,
            entity.Name,
            entity.Categories,
            entity.Description,
            entity.ImageFile,
            entity.Price
        );
    }
}
