namespace Catalog.API.Products.GetProducts;

public record ProductDto(
    Guid Id,
    string Name,
    IList<string> Categories,
    string Description,
    string ImageFile,
    decimal Price);