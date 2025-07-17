using System.Text.Json;

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

        var (stackTrace, message, statusCode) = exception switch
        {
            IOException => (
                exception.StackTrace,
                exception.Message,
                StatusCodes.Status400BadRequest
            ),
            ArgumentException => (
                exception.StackTrace,
                exception.Message,
                StatusCodes.Status400BadRequest
            ),
            InvalidOperationException => (
                exception.StackTrace,
                exception.Message,
                StatusCodes.Status400BadRequest
            ),
            _ => (
                exception.StackTrace,
                exception.Message,
                StatusCodes.Status500InternalServerError
            )
        };
        
        var response = new Response<Unit>(
            false,
            statusCode,
            new Unit(),
            message,
            stackTrace?.Trim()
        );
        
        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsJsonAsync(response, cancellationToken);
        return true;
    }
}