namespace Shared.CQRS;

using MediatR;
using Models;

public interface IQuery<TResponse> : IRequest<Response<TResponse>>
    where TResponse : notnull;

public interface IPagedQuery<TResponse> : IQuery<PagedResponse<TResponse>>
    where TResponse : notnull;