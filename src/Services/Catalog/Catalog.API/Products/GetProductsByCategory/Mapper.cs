namespace Catalog.API.Products.GetProductsByCategory;

using Endpoint;
using Handler;

public static class Mapper
{
    public static GetProductsByCategoryQuery ToQuery(this GetProductsByCategoryRequest request)
    {
        return new GetProductsByCategoryQuery(request.Category);
    }

    public static Response<GetProductsByCategoryResponse> ToResponse(
        this Response<GetProductsByCategoryResult> result)
    {
        return new(
            result.IsSuccess,
            result.StatusCode,
            new GetProductsByCategoryResponse(result.Result?.Products ?? []),
            result.ErrorMessage,
            result.ErrorDetails);
    }
}
