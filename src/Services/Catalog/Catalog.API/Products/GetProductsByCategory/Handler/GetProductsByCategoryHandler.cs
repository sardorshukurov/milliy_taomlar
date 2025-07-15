
namespace Catalog.API.Products.GetProductsByCategory.Handler;

using Entities;
using GetProducts;

public class GetProductsByCategoryHandler(IDocumentSession session)
    : IQueryHandler<GetProductsByCategoryQuery, GetProductsByCategoryResult>
{
    public async Task<Response<GetProductsByCategoryResult>> Handle(
        GetProductsByCategoryQuery request, CancellationToken cancellationToken)
    {
        var products = (await session.Query<Product>()
            .Where(p => p.Categories.Any(
                c => c.Contains(request.Category, StringComparison.OrdinalIgnoreCase)))
            .ToListAsync(cancellationToken))
            .Select(p => p.ToDto());

        var result = new Response<GetProductsByCategoryResult>(
            true,
            StatusCodes.Status200OK,
            new(products));

        return result;
    }
}
