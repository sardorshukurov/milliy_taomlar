namespace Catalog.API.Products.UpdateProduct.Handler;

public record UpdateProductCommand(
    Guid Id,
    string Name,
    IList<string> Categories,
    string Description,
    string ImageFile,
    decimal Price) : ICommand;