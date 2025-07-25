namespace Shared.Behaviors;

using System.Net;
using FluentValidation;
using MediatR;
using Models;
using Helpers;
using Microsoft.Extensions.Logging;

public class ValidationBehavior<TRequest, TResponse>(
    IEnumerable<IValidator<TRequest>> validators,
    ILogger<ValidationBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!validators.Any())
        {
            logger.LogWarning("No validators found for {RequestType} - proceeding to next handler", typeof(TRequest).Name);
            return await next(cancellationToken);
        }

        var context = new ValidationContext<TRequest>(request);

        var validationResults =
            await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        var failures = validationResults
            .Where(r => r.Errors.Any())
            .SelectMany(r => r.Errors)
            .ToList();

        logger.LogWarning("Validation completed with {ErrorCount} errors", failures.Count);

        if (failures.Any())
        {
            logger.LogWarning("Validation failed with errors: {Errors}",
                string.Join(", ", failures.Select(f => f.ErrorMessage)));

            // Check if TResponse is Response<T>
            if (typeof(TResponse).IsGenericType &&
                typeof(TResponse).GetGenericTypeDefinition() == typeof(Response<>))
            {
                var responseInstance = Activator.CreateInstance(typeof(TResponse),
                    false,                                                    // IsSuccess
                    (int)HttpStatusCode.BadRequest,                          // StatusCode
                    null,                                                    // Result
                    ValidationHelper.GetValidationErrorMessage(failures),   // ErrorMessage
                    null);                                                   // ErrorDetails

                return (TResponse)responseInstance!;
            }
        }

        logger.LogWarning("Validation passed - proceeding to next handler");
        return await next(cancellationToken);
    }
}