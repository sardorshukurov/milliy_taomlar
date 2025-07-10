namespace Catalog.API.Products.DeleteProduct.Handler;

using Entities;

public class DeleteProductHandler (
    IDocumentSession session, ILogger<DeleteProductHandler> logger)
    : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(
        DeleteProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogHandler(nameof(DeleteProductHandler), command.ToString());

        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);
        
        if (product is null)
        {
            return new DeleteProductResult(false);
        }
        
        session.Delete(product);
        await session.SaveChangesAsync(cancellationToken);
        
        return new DeleteProductResult(true);
    }
}