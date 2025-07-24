using Ordering.Application.Orders.Queries.GetOrdersByCustomer;

namespace Ordering.API.Endpoints.GetOrdersByCustomer;

public static class Mappers
{
    public static Response<GetOrdersByCustomerResponse> ToResponse(
        this Response<GetOrdersByCustomerResult> result)
    {
        return new Response<GetOrdersByCustomerResponse>(
            result.IsSuccess,
            result.StatusCode,
            result.Result is null ? null : new(result.Result.Orders),
            result.ErrorMessage,
            result.ErrorDetails
        );
    }
}
