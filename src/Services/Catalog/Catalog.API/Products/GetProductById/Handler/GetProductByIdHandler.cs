
using Catalog.API.Entities;
using Catalog.API.Products.GetProducts;

namespace Catalog.API.Products.GetProductById.Handler;

public class GetProductByIdHandler(IDocumentSession session)
    : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(
        GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(query.Id, cancellationToken);

        return new GetProductByIdResult(product?.ToDto());
    }
}
