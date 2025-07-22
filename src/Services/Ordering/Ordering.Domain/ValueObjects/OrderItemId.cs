namespace Ordering.Domain.ValueObjects;

public record OrderItemId
{
    public Guid Value { get; }

    private OrderItemId(Guid value) => Value = value;

    public static OrderItemId Of(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException(
                "OrderItemId cannot be empty", nameof(value));
        }

        return new OrderItemId(value);
    }

    public static OrderItemId New() => new(Guid.NewGuid());
}
