namespace Catalog.API.Products.GetProductsByCategory.Endpoint;

using Catalog.API.Products.GetProducts.Dtos;

public record GetProductsByCategoryResponse(IEnumerable<ProductDto> Products);