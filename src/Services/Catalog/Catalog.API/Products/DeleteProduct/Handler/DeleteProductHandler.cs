namespace Catalog.API.Products.DeleteProduct.Handler;

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
                StatusCodes.Status404NotFound,
                Unit.Value,
                "Product not found");
        }

        session.Delete(product);
        await session.SaveChangesAsync(cancellationToken);

        return new Response<Unit>(
            true, StatusCodes.Status200OK, Unit.Value);
    }
}