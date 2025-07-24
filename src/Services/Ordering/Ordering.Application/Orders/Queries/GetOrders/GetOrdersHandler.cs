namespace Ordering.Application.Orders.Queries.GetOrders;

using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Dtos;
using Orders;

public class GetOrdersHandler(IOrderingDbContext dbContext)
    : IQueryHandler<GetOrdersQuery, PagedResponse<OrderDto>>
{
    public async Task<Response<PagedResponse<OrderDto>>> Handle(
        GetOrdersQuery query, CancellationToken cancellationToken)
    {
        if (query.Request?.Filters is not null)
        {
            // TODO: apply filters
        }

        var totalCount = await dbContext.Orders.LongCountAsync(cancellationToken);

        var page = query.Request?.Page ?? 1;
        var pageSize = query.Request?.PageSize ?? 10;

        var orders = await dbContext.Orders
            .Include(o => o.Items)
            .AsNoTracking()
            .OrderBy(o => o.Name.Value)
            .Skip(page * pageSize)
            .Take(pageSize)
            .Select(o => o.ToDto())
            .ToListAsync(cancellationToken);

        var totalPages = (long)Math.Ceiling((double)totalCount / pageSize);

        return new Response<PagedResponse<OrderDto>>(
            true,
            StatusCodes.Status200OK,
            new PagedResponse<OrderDto>(
                page,
                pageSize,
                totalCount,
                totalPages,
                orders));
    }
}
