namespace Shared.Extensions;

using Microsoft.Extensions.Logging;

public static class LoggerExtensions
{
    public static void LogHandler(this ILogger logger, string handlerName, string request = "")
    {
        logger.LogInformation(
            "{HandlerName}.Handle called with {Request}", handlerName, request);
    }
}
