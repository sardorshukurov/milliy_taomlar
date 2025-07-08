namespace Catalog.API.Products.CreateProduct.Endpoint;

public record CreateProductRequest(
    string Name,
    IList<string> Categories,
    string Description,
    string ImageFile,
    decimal Price
);
