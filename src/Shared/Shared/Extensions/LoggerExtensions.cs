namespace Shared.Extensions;

using System.Diagnostics;
using Microsoft.Extensions.Logging;

public static class LoggerExtensions
{
    public static void LogHandlerStart<TRequest, TResponse>(this ILogger logger)
    {
        logger.LogInformation(
            "[START] Handler request={Request} - Response={Response}",
            typeof(TRequest).Name,
            typeof(TResponse).Name);
    }

    public static void LogHandlerEnd<TRequest, TResponse>(this ILogger logger, double timeTaken)
    {
        logger.LogInformation(
            "[END] Handler request={Request} - Response={Response} - Elapsed={Elapsed}ms",
            typeof(TRequest).Name,
            typeof(TResponse).Name,
            timeTaken);
    }
}
