namespace Shared.Extensions;

using Microsoft.AspNetCore.Http;
using Models;
using CQRS;

public static class ResponseExtensions
{
    public static IResult ToResult<T>(
        this Response<T> response, Func<Response<T>, IResult> onSuccess)
    {
        return new ResponseResult<T>(response, onSuccess);
    }
}
