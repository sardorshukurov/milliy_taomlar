namespace Catalog.API.Products.GetProductsByCategory.Endpoint;

using Dtos;

public record GetProductsByCategoryResponse(IEnumerable<ProductDto> Products);