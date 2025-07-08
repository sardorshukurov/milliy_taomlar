namespace Catalog.API.Products.CreateProduct.Handler;

using Catalog.API.Entities;
using Shared.CQRS;

internal class CreateProductHandler
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(
        CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = command.Name,
            Categories = command.Categories,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price,
        };

        return new CreateProductResult(product.Id);
    }
}
