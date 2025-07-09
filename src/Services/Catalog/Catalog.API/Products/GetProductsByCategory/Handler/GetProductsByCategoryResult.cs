namespace Catalog.API.Products.GetProductsByCategory.Handler;

using Catalog.API.Products.GetProducts.Dtos;

public record GetProductsByCategoryResult(IEnumerable<ProductDto> Products);