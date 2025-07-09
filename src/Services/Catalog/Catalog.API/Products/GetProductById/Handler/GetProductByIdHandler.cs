
using Catalog.API.Entities;
using Catalog.API.Products.GetProducts;

namespace Catalog.API.Products.GetProductById.Handler;

public class GetProductByIdHandler(
    IDocumentSession session, ILogger<GetProductByIdHandler> logger)
    : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(
        GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        logger.LogHandler(nameof(GetProductByIdHandler), query.ToString());

        var product = await session.LoadAsync<Product>(query.Id, cancellationToken);

        return new GetProductByIdResult(product?.ToDto());
    }
}
