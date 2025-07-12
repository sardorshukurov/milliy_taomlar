using Catalog.API.Products.Dtos;

namespace Catalog.API.Products.GetProducts;

using Entities;
using Endpoint;
using Handler;

public static class Mapper
{
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
