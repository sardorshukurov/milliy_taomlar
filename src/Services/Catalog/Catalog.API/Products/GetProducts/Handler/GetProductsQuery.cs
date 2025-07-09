namespace Catalog.API.Products.GetProducts.Handler;

public record GetProductsQuery(
    string Name,
    IList<string> Categories,
    decimal MinimumPrice,
    decimal MaximumPrice
) : IQuery<GetProductsResult>;
