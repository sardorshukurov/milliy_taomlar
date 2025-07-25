
using MediatR;
using Shared.Models;

namespace Shared.CQRS;

public interface IQueryHandler<in TQuery>
    : IQueryHandler<TQuery, Unit>
    where TQuery : IQuery<Unit>;

public interface IQueryHandler<in TQuery, TResponse>
    : IRequestHandler<TQuery, Response<TResponse>>
    where TQuery : IQuery<TResponse>
    where TResponse : notnull;

public interface IPagedQueryHandler<in TQuery, TResponse>
    : IRequestHandler<TQuery, Response<PagedResponse<TResponse>>>
    where TQuery : IPagedQuery<TResponse>
    where TResponse : notnull;