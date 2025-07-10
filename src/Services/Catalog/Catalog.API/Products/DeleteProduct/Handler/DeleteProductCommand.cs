namespace Catalog.API.Products.DeleteProduct.Handler;

public record DeleteProductCommand(Guid Id)
    : ICommand<DeleteProductResult>;