
using Catalog.API.Entities;
using Catalog.API.Products.GetProducts;

namespace Catalog.API.Products.GetProductById.Handler;

public class GetProductByIdHandler(IDocumentSession session)
    : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<Response<GetProductByIdResult>> Handle(
        GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(query.Id, cancellationToken);

        if (product is null)
        {
            return new(
                false,
                StatusCodes.Status404NotFound,
                null,
                "Product not found"
            );
        }

        var result = new GetProductByIdResult(product.ToDto());
        return new(
            true,
            StatusCodes.Status200OK,
            result
        );
    }
}
