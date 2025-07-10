namespace Catalog.API.Products.UpdateProduct.Endpoint;

public record UpdateProductRequest(
    Guid Id,
    string Name,
    IList<string> Categories,
    string Description,
    string ImageFile,
    decimal Price);