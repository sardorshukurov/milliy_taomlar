namespace Ordering.Application.Orders.Queries.GetOrdersByCustomer;

using Dtos;

public record GetOrdersByCustomerResult(IEnumerable<OrderDto> Orders);
