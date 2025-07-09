namespace Catalog.API.Products.GetProducts.Endpoint;

public record GetProductsResponse(IEnumerable<ProductDto> Products);