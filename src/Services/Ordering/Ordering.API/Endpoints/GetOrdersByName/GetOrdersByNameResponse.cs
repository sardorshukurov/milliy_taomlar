namespace Ordering.API.Endpoints.GetOrdersByName;

using Application.Dtos;

public record GetOrdersByNameResponse(IEnumerable<OrderDto> Orders);