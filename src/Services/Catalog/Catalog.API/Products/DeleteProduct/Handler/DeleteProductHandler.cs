namespace Catalog.API.Products.DeleteProduct.Handler;

using System.Net;
using Entities;

public class DeleteProductHandler(IDocumentSession session)
    : ICommandHandler<DeleteProductCommand>
{
    public async Task<Response<Unit>> Handle(
        DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

        if (product is null)
        {
            return new Response<Unit>(
                false,
                (int)HttpStatusCode.NotFound,
                new Unit(),
                "Product not found");
        }

        session.Delete(product);
        await session.SaveChangesAsync(cancellationToken);

        return new Response<Unit>(
            true, (int)HttpStatusCode.OK, new Unit());
    }
}