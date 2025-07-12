namespace Shared.CQRS;

using MediatR;
using Models;

public interface IQuery<out TResponse> : IRequest<TResponse>
    where TResponse : notnull;

public interface IPagedQuery<TResponse> : IQuery<PagedResponse<TResponse>>
    where TResponse : notnull;