namespace Ordering.Application.Orders.Queries.GetOrdersByCustomer;

using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Ordering.Domain.ValueObjects;
using Orders;

public class GetOrdersByCustomerHandler(IOrderingDbContext dbContext)
    : IQueryHandler<GetOrdersByCustomerQuery, GetOrdersByCustomerResult>
{
    public async Task<Response<GetOrdersByCustomerResult>> Handle(
        GetOrdersByCustomerQuery query, CancellationToken cancellationToken)
    {
        var orders = await dbContext.Orders
            .Include(o => o.Items)
            .AsNoTracking()
            .Where(o => o.CustomerId == CustomerId.Of(query.CustomerId))
            .OrderByDescending(o => o.Name.Value)
            .Select(o => o.ToDto())
            .ToListAsync(cancellationToken);

        return new Response<GetOrdersByCustomerResult>(
            true,
            StatusCodes.Status200OK,
            new GetOrdersByCustomerResult(orders));
    }
}
