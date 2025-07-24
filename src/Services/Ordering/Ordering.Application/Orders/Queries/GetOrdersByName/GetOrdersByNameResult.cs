namespace Ordering.Application.Orders.Queries.GetOrdersByName;

using Dtos;

public record GetOrdersByNameResult(IEnumerable<OrderDto> Orders);
