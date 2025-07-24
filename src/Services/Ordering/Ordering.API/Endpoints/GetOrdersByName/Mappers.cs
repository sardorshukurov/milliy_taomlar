using Ordering.Application.Orders.Queries.GetOrdersByName;

namespace Ordering.API.Endpoints.GetOrdersByName;

public static class Mappers
{
    public static Response<GetOrdersByNameResponse> ToResponse(
        this Response<GetOrdersByNameResult> result)
    {
        return new Response<GetOrdersByNameResponse>(
            result.IsSuccess,
            result.StatusCode,
            result.Result is null ? null : new (result.Result.Orders),
            result.ErrorMessage,
            result.ErrorDetails);
    }
}
