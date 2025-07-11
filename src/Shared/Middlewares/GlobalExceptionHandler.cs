namespace Shared.Middlewares;

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Models;
using Microsoft.AspNetCore.Diagnostics;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext context, Exception exception, CancellationToken cancellationToken)
    {
        logger.LogError("Error Message: {exceptionMessage}, Time of Occurence: {time}",
            exception.Message, DateTime.UtcNow);

        var (details, message, statusCode) = exception switch
        {
            ArgumentException => (
                Details: exception.StackTrace,
                Message: exception.Message,
                StatusCode: StatusCodes.Status400BadRequest
            ),
            InvalidOperationException => (
                Details: exception.StackTrace,
                Message: exception.Message,
                StatusCode: StatusCodes.Status400BadRequest
            ),
            _ => (
                Details: exception.StackTrace,
                Message: exception.Message,
                StatusCode: StatusCodes.Status500InternalServerError
            )
        };
        
        var response = new Response<Unit>(
            false,
            statusCode,
            new Unit(),
            message,
            details?.Trim()
        );
        
        await context.Response.WriteAsJsonAsync(response, cancellationToken);
        return true;
    }
}