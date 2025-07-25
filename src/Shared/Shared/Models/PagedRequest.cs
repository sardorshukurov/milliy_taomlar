namespace Shared.Models;

public record PagedRequest<T>(
    int Page = 1,
    int PageSize = 10,
    T? Filters = default,
    string? SortBy = null,
    bool? SortDescending = false);
