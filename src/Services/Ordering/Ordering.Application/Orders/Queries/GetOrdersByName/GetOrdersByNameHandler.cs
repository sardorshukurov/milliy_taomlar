namespace Ordering.Application.Orders.Queries.GetOrdersByName;

using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Orders;

public class GetOrdersByNameHandler(IOrderingDbContext dbContext)
    : IQueryHandler<GetOrdersByNameQuery, GetOrdersByNameResult>
{
    public async Task<Response<GetOrdersByNameResult>> Handle(
        GetOrdersByNameQuery query, CancellationToken cancellationToken)
    {
        var orders = await dbContext.Orders
            .Include(o => o.Items)
            .AsNoTracking()
            .Where(o => o.Name.Value.Contains(query.Name))
            .OrderByDescending(o => o.Name.Value)
            .Select(o => o.ToDto())
            .ToListAsync(cancellationToken);

        return new Response<GetOrdersByNameResult>(
            true,
            StatusCodes.Status200OK,
            new GetOrdersByNameResult(orders));
    }
}
