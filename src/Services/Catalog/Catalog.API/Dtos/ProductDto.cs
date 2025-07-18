namespace Catalog.API.Dtos;

public record ProductDto(
    Guid Id,
    string Name,
    IList<string> Categories,
    string Description,
    string ImageFile,
    decimal Price);