
using Catalog.API.Entities;

namespace Catalog.API.Products.GetProducts.Handler;

public class GetProductsHandler(IDocumentSession session, ILogger<GetProductsHandler> logger)
    : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(
        GetProductsQuery request, CancellationToken cancellationToken)
    {
        logger.LogHandler(nameof(GetProductsHandler), request.ToString());

        var products = (await session.Query<Product>()
            .ToListAsync(cancellationToken))
            .Select(p => p.ToDto());

        var result = new GetProductsResult(products);

        return result;
    }
}
