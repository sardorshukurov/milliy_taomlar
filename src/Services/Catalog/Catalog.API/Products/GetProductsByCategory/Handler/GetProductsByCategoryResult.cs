namespace Catalog.API.Products.GetProductsByCategory.Handler;

using Dtos;

public record GetProductsByCategoryResult(IEnumerable<ProductDto> Products);