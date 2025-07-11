namespace Shared.Helpers;

using FluentValidation.Results;

public static class ValidationHelper
{
    public static string GetValidationErrorMessage(List<ValidationFailure> errors)
    {
        return errors.Select(e => $"{e.ErrorCode}: {e.ErrorMessage}")
                     .Aggregate((current, next) => $"{current} {next}");
    }
}