namespace Catalog.API.Products.GetProductsByCategory.Handler;

public record GetProductsByCategoryQuery(string Category)
    : IQuery<GetProductsByCategoryResult>;
