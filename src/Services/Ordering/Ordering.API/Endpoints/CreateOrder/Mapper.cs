namespace Ordering.API.Endpoints.CreateOrder;

using Application.Orders.Commands.CreateOrder;

public static class Mapper
{
    public static CreateOrderCommand ToCommand(this CreateOrderRequest request)
    {
        return new(
            request.CustomerId,
            request.Name,
            request.ShippingAddress,
            request.BillingAddress,
            request.Payment,
            request.Status,
            request.Items
        );
    }

    public static Response<CreateOrderResponse> ToResponse(this Response<CreateOrderResult> result)
    {
        return new Response<CreateOrderResponse>(
            result.IsSuccess,
            result.StatusCode,
            result.Result is null ? null : new (result.Result.OrderId),
            result.ErrorMessage,
            result.ErrorDetails);
    }
}
