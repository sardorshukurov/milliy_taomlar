
namespace Catalog.API.Products.GetProductsByCategory.Handler;

using Catalog.API.Entities;
using Catalog.API.Products.GetProducts;

public class GetProductsByCategoryHandler(
    IDocumentSession session, ILogger<GetProductsByCategoryHandler> logger)
    : IQueryHandler<GetProductsByCategoryQuery, GetProductsByCategoryResult>
{
    public async Task<GetProductsByCategoryResult> Handle(
        GetProductsByCategoryQuery request, CancellationToken cancellationToken)
    {
        logger.LogHandler(nameof(GetProductsByCategoryHandler), request.ToString());

        var products = (await session.Query<Product>()
            .Where(p => p.Categories.Any(
                c => c.Contains(request.Category, StringComparison.OrdinalIgnoreCase)))
            .ToListAsync(cancellationToken))
            .Select(p => p.ToDto());

        return new GetProductsByCategoryResult(products);
    }
}
