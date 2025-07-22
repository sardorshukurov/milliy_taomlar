namespace Ordering.Domain.ValueObjects;

public record CustomerId
{
    public Guid Value { get; }

    private CustomerId(Guid value) => Value = value;

    public static CustomerId Of(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException(
                "CustomerId cannot be empty", nameof(value));
        }

        return new CustomerId(value);
    }

    public static CustomerId New() => new(Guid.NewGuid());
}
