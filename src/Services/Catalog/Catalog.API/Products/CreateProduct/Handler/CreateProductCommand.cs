namespace Catalog.API.Products.CreateProduct.Handler;

public record CreateProductCommand(
    string Name,
    IList<string> Categories,
    string Description,
    string ImageFile,
    decimal Price) : ICommand<CreateProductResult>;
