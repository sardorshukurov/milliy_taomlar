namespace Ordering.Application.Orders.Commands.CreateOrder;

using Dtos;
using Domain.Enums;

public record CreateOrderCommand(
    Guid CustomerId,
    string Name,
    AddressDto ShippingAddress,
    AddressDto BillingAddress,
    PaymentDto Payment,
    OrderStatus Status,
    List<OrderItemDto> Items
) : ICommand<CreateOrderResult>;
