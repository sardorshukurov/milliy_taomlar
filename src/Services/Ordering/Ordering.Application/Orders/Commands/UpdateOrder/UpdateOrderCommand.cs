namespace Ordering.Application.Orders.Commands.UpdateOrder;

using Dtos;

public record UpdateOrderCommand(OrderDto Order) : ICommand;
