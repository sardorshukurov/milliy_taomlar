namespace Ordering.Domain.Entities;

public class Order : Aggregate<OrderId>
{
    private readonly List<OrderItem> _items = [];

    public IReadOnlyList<OrderItem> Items => _items.AsReadOnly();

    public CustomerId CustomerId { get; private set; } = default!;

    public OrderName Name { get; private set; } = default!;

    public Address ShippingAddress { get; set; } = default!;

    public Address BillingAddress { get; set; } = default!;

    public Payment Payment { get; set; } = default!;

    public OrderStatus Status { get; private set; } = OrderStatus.Pending;

    public decimal TotalPrice
    {
        get => Items.Sum(i => i.Price * i.Quantity);
        private set { }
    }

    public static Order Create(
        OrderId id,
        CustomerId customerId,
        OrderName name,
        Address shippingAddress,
        Address billingAddress,
        Payment payment)
    {
        var order = new Order
        {
            Id = id,
            CustomerId = customerId,
            Name = name,
            ShippingAddress = shippingAddress,
            BillingAddress = billingAddress,
            Payment = payment,
            Status = OrderStatus.Pending
        };

        order.AddDomainEvent(new OrderCreatedEvent(order));

        return order;
    }

    public void Update(
        OrderName orderName,
        Address shippingAddress,
        Address billingAddress,
        Payment payment,
        OrderStatus status)
    {
        Name = orderName;
        ShippingAddress = shippingAddress;
        BillingAddress = billingAddress;
        Payment = payment;
        Status = status;

        AddDomainEvent(new OrderUpdatedEvent(this));
    }

    public void AddItem(ProductId productId, int quantity, decimal price)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        var item = new OrderItem(Id, productId, quantity, price);
        _items.Add(item);
    }

    public void RemoveItem(ProductId productId)
    {
        var item = _items.FirstOrDefault(i => i.ProductId == productId);

        if (item is not null)
        {
            _items.Remove(item);
        }
    }
}
