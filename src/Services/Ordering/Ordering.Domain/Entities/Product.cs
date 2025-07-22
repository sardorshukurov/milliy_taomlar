namespace Ordering.Domain.Entities;

public class Product : Entity<ProductId>
{
    public string Name { get; private set; } = string.Empty;

    public decimal Price { get; private set; }

    public static Product Create(ProductId id, string name, decimal price)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        var product = new Product
        {
            Id = id,
            Name = name,
            Price = price
        };

        return product;
    }
}
