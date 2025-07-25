namespace Shared.Models;

public record Response<T>(
    bool IsSuccess,
    int StatusCode,
    T? Result,
    string? ErrorMessage = null,
    string? ErrorDetails = null);