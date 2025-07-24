namespace Ordering.Application.Orders.Commands.UpdateOrder;

using Data;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Http;

public class UpdateOrderHandler(IOrderingDbContext dbContext)
    : ICommandHandler<UpdateOrderCommand, Unit>
{
    public async Task<Response<Unit>> Handle(
        UpdateOrderCommand command, CancellationToken cancellationToken)
    {
        var orderId = OrderId.Of(command.Order.Id);
        var order = await dbContext.Orders.FindAsync(
            [orderId],
            cancellationToken: cancellationToken);

        if (order is null)
        {
            return new Response<Unit>(
                false,
                StatusCodes.Status404NotFound,
                Unit.Value);
        }

        order.UpdateEntity(command);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new Response<Unit>(
            true,
            StatusCodes.Status200OK,
            Unit.Value);
    }
}
