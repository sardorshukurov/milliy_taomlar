namespace Catalog.API.Products.GetProducts.Endpoint;

using Catalog.API.Products.GetProducts.Dtos;

public record GetProductsResponse(IEnumerable<ProductDto> Products);