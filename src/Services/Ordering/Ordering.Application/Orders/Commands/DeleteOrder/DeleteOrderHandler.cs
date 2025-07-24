namespace Ordering.Application.Orders.Commands.DeleteOrder;

using Data;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Http;

public class DeleteOrderHandler(IOrderingDbContext dbContext)
    : ICommandHandler<DeleteOrderCommand, Unit>
{
    public async Task<Response<Unit>> Handle(
        DeleteOrderCommand command, CancellationToken cancellationToken)
    {
        var orderId = OrderId.Of(command.OrderId);
        var order = await dbContext.Orders.FindAsync(
            [orderId], cancellationToken: cancellationToken);

        if (order is null)
        {
            return new Response<Unit>(
                false,
                StatusCodes.Status404NotFound,
                Unit.Value);
        }

        dbContext.Orders.Remove(order);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new Response<Unit>(
            true,
            StatusCodes.Status200OK,
            Unit.Value);
    }
}
