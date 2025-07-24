namespace Ordering.Application.Orders.Queries.GetOrders;

using Dtos;
using Shared.Models;

public record GetOrdersQuery(PagedRequest<GetOrdersFilter>? Request) : IPagedQuery<OrderDto>;

public record GetOrdersFilter(
    string? Name,
    IList<string>? Customers,
    IList<string>? Statuses,
    DateTime? StartDate,
    DateTime? EndDate,
    decimal? TotalPriceFrom,
    decimal? TotalPriceTo
);
