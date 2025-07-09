namespace Catalog.API.Products.GetProducts.Handler;

using Catalog.API.Products.GetProducts.Dtos;

public record GetProductsResult(IEnumerable<ProductDto> Products);