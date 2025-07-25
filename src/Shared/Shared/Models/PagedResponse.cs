namespace Shared.Models;

public record PagedResponse<T>(
    long Page,
    long PageSize,
    long TotalItems,
    long TotalPages,
    IEnumerable<T> Items);