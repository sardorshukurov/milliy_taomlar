namespace Catalog.API.Products.CreateProduct.Handler;

internal class CreateProductHandler(
    IDocumentSession session, ILogger<CreateProductHandler> logger)
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<Response<CreateProductResult>> Handle(
        CreateProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogHandler(nameof(CreateProductHandler), command.ToString());

        var product = command.ToEntity();

        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        var result = new CreateProductResult(product.Id);
        var response = new Response<CreateProductResult>(
            true,
            StatusCodes.Status201Created,
            result);

        return response;
    }
}
