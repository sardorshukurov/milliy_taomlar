namespace Ordering.API.Endpoints.UpdateOrder;

using Application.Orders.Commands.UpdateOrder;

public static class Mapper
{
    public static UpdateOrderCommand ToCommand(this UpdateOrderRequest request)
    {
        return new(request.Order);
    }
}
