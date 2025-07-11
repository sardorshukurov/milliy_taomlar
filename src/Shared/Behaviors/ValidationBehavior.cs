namespace Shared.Behaviors;

using System.Net;
using CQRS;
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
        logger.LogWarning("====== ValidationBehavior.Handle called ======");

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
                var innerType = typeof(TResponse).GetGenericArguments()[0];
                var responseInstance = Activator.CreateInstance(typeof(TResponse),
                    false,
                    (int)HttpStatusCode.BadRequest,
                    null,
                    ValidationHelper.GetValidationErrorMessage(failures));
                return (TResponse)responseInstance!;
            }

            // Fallback - throw exception for non-Response types
            throw new ValidationException(failures);
        }

        logger.LogWarning("Validation passed - proceeding to next handler");
        return await next(cancellationToken);
    }
}