namespace Catalog.API.Entities;

public class Product
{
    public Guid Id { get; init; }

    public string Name { get; set; } = string.Empty;

    public IList<string> Categories { get; set; } = [];

    public string Description { get; set; } = string.Empty;

    public string ImageFile { get; set; } = string.Empty;

    public decimal Price { get; set; }
}
