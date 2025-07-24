namespace Ordering.Application.Orders.Commands.CreateOrder;

using Data;
using Microsoft.AspNetCore.Http;

public class CreateOrderHandler(IOrderingDbContext dbContext)
    : ICommandHandler<CreateOrderCommand, CreateOrderResult>
{
    public async Task<Response<CreateOrderResult>> Handle(
        CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var order = command.ToEntity();

        dbContext.Orders.Add(order);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new Response<CreateOrderResult>(
            true,
            StatusCodes.Status201Created,
            new CreateOrderResult(order.Id.Value));
    }
}
