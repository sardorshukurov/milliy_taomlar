namespace Ordering.Application.Dtos;

using Domain.Enums;

public record OrderDto(
    Guid Id,
    Guid CustomerId,
    string Name,
    AddressDto ShippingAddress,
    AddressDto BillingAddress,
    PaymentDto Payment,
    OrderStatus Status,
    List<OrderItemDto> Items
);
