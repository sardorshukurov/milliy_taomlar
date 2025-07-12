using Marten.Pagination;

namespace Catalog.API.Products.GetProducts.Handler;

using Entities;
using Dtos;

public class GetProductsHandler(IDocumentSession session)
    : IQueryHandler<GetProductsQuery, PagedResponse<ProductDto>>
{
    public async Task<PagedResponse<ProductDto>> Handle(
        GetProductsQuery query, CancellationToken cancellationToken)
    {
        var productQuery = session.Query<Product>().AsQueryable();

        var filter = query.Request?.Filters;
        if (filter is not null)
        {
            // Apply filters
            if (!string.IsNullOrEmpty(filter.Name))
            {
                productQuery = productQuery.Where(p =>
                    p.Name.Contains(filter.Name, StringComparison.OrdinalIgnoreCase));
            }

            if (filter.Categories.Any())
            {
                productQuery = productQuery.Where(p =>
                    p.Categories.Any(c => filter.Categories.Contains(c)));
            }

            if (filter.MinimumPrice > 0)
            {
                productQuery = productQuery.Where(p =>
                    p.Price >= filter.MinimumPrice);
            }

            if (filter.MaximumPrice < decimal.MaxValue)
            {
                productQuery = productQuery.Where(p =>
                    p.Price <= filter.MaximumPrice);
            }
        }

        // Apply sorting
        if (!string.IsNullOrEmpty(query.Request?.SortBy))
        {
            productQuery = query.Request.SortBy.ToLower() switch
            {
                "name" => query.Request.SortDescending == true
                    ? productQuery.OrderByDescending(p => p.Name)
                    : productQuery.OrderBy(p => p.Name),
                "price" => query.Request.SortDescending == true
                    ? productQuery.OrderByDescending(p => p.Price)
                    : productQuery.OrderBy(p => p.Price),
                _ => productQuery.OrderBy(p => p.Name) // Default sorting
            };
        }
        else
        {
            productQuery = productQuery.OrderBy(p => p.Name); // Default sorting
        }

        // Apply pagination
        var page = query.Request?.Page ?? 1;
        var pageSize = query.Request?.PageSize ?? 10;

        var products = await productQuery.ToPagedListAsync(
            page, pageSize, cancellationToken);

        var productDtos = products.Select(p => p.ToDto()).ToList();

        return new PagedResponse<ProductDto>(
            products.PageNumber,
            products.PageSize,
            products.TotalItemCount,
            products.PageCount,
            productDtos
        );
    }
}
