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
        if (query.Request.Filters is not null)
        {
            // TODO: apply filters
        }

        var totalCount = await dbContext.Orders.LongCountAsync(cancellationToken);
        var orders = await dbContext.Orders
            .Include(o => o.Items)
            .AsNoTracking()
            .OrderBy(o => o.Name.Value)
            .Skip(query.Request.Page * query.Request.PageSize)
            .Take(query.Request.PageSize)
            .Select(o => o.ToDto())
            .ToListAsync(cancellationToken);

        var totalPages = (long)Math.Ceiling((double)totalCount / query.Request.PageSize);

        return new Response<PagedResponse<OrderDto>>(
            true,
            StatusCodes.Status200OK,
            new PagedResponse<OrderDto>(
                query.Request.Page,
                query.Request.PageSize,
                totalCount,
                totalPages,
                orders));
    }
}
