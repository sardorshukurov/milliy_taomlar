namespace Catalog.API.Products.GetProductById;

using Endpoint;
using Handler;

public static class Mapper
{
    public static Response<GetProductByIdResponse> ToResponse(
        this Response<GetProductByIdResult> result)
    {
        return new(
            result.IsSuccess,
            result.StatusCode,
            new(result.Result?.Product),
            result.ErrorMessage,
            result.ErrorMessage
        );
    }
}
