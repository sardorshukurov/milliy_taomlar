namespace Catalog.API.Products.GetProducts.Handler;

public record GetProductsResult(IEnumerable<ProductDto> Products);