namespace Ordering.API.Endpoints.CreateOrder;

using Application.Dtos;
using Domain.Enums;

public record CreateOrderRequest(
    Guid CustomerId,
    string Name,
    AddressDto ShippingAddress,
    AddressDto BillingAddress,
    PaymentDto Payment,
    OrderStatus Status,
    List<OrderItemDto> Items
);
