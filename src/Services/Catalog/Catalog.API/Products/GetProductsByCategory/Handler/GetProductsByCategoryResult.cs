using Catalog.API.Products.Dtos;

namespace Catalog.API.Products.GetProductsByCategory.Handler;

public record GetProductsByCategoryResult(IEnumerable<ProductDto> Products);