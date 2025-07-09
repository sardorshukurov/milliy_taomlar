namespace Catalog.API.Products.GetProducts.Endpoint;

public record GetProductsRequest(
    string? Name = null,
    IList<string>? Categories = null,
    decimal MinimumPrice = 0,
    decimal MaximumPrice = decimal.MaxValue
);
