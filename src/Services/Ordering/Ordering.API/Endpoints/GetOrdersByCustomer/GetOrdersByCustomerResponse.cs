namespace Ordering.API.Endpoints.GetOrdersByCustomer;

using Application.Dtos;

public record GetOrdersByCustomerResponse(IEnumerable<OrderDto> Orders);