namespace Shared.Behaviors;

using System.Diagnostics;
using Extensions;
using MediatR;
using Microsoft.Extensions.Logging;

public class LoggingBehavior<TRequest, TResponse>(
    ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        logger.LogHandlerStart<TRequest, TResponse>();

        var timer = new Stopwatch();
        timer.Start();

        var response = await next();

        timer.Stop();

        var timeTaken = timer.Elapsed;

        if (timeTaken.Seconds > 2)
        {
            logger.LogWarning(
                "[PERFORMANCE] The request {Request} took {TimeTaken}ms to complete",
                typeof(TRequest).Name,
                timeTaken.TotalMilliseconds);
        }

        logger.LogHandlerEnd<TRequest, TResponse>(timeTaken.TotalMilliseconds);

        return response;
    }
}
