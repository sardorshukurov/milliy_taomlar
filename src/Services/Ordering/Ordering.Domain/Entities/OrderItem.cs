namespace Ordering.Domain.Entities;

public class OrderItem : Entity<OrderItemId>
{
    internal OrderItem(
        OrderId orderId,
        ProductId productId,
        int quantity,
        decimal price)
    {
        Id = OrderItemId.New();
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
        Price = price;
    }

    public OrderId OrderId { get; private set; } = default!;

    public ProductId ProductId { get; private set; } = default!;

    public int Quantity { get; private set; }

    public decimal Price { get; private set; }
}
