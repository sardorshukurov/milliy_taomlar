namespace Shared.CQRS;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Models;

public class ResponseResult<T>(Response<T> response, Func<Response<T>, IResult> onSuccess)
    : IResult
{
    public async Task ExecuteAsync(HttpContext httpContext)
    {
        if (response.IsSuccess)
        {
            var successResult = onSuccess(response);
            await successResult.ExecuteAsync(httpContext);
            return;
        }

        httpContext.Response.StatusCode = response.StatusCode;

        await httpContext.Response.WriteAsJsonAsync(response);
    }
}
