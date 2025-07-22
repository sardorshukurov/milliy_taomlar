namespace Ordering.Domain.ValueObjects;

public record ProductId
{
    public Guid Value { get; }

    private ProductId(Guid value) => Value = value;

    public static ProductId Of(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException(
                "ProductId cannot be empty", nameof(value));
        }

        return new ProductId(value);
    }

    public static ProductId New() => new(Guid.NewGuid());
}
