namespace Catalog.API.Products.GetProducts.Handler;

using Dtos;

public record GetProductsQuery(PagedRequest<GetProductsFilter>? Request)
    : IPagedQuery<ProductDto>;

public record GetProductsFilter(
    string Name,
    IList<string> Categories,
    decimal MinimumPrice,
    decimal MaximumPrice
);