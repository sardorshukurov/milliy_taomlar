namespace Catalog.API.Products.CreateProduct.Handler;

internal class CreateProductHandler(IDocumentSession session)
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(
        CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = command.ToEntity();

        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        return new CreateProductResult(product.Id);
    }
}
