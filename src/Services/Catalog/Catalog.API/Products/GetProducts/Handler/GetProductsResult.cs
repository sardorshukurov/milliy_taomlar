using Catalog.API.Products.Dtos;

namespace Catalog.API.Products.GetProducts.Handler;

public record GetProductsResult(IEnumerable<ProductDto> Products);