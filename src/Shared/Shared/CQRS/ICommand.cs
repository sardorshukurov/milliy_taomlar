namespace Shared.CQRS;

using MediatR;
using Shared.Models;

public interface ICommand : ICommand<Unit>;

public interface ICommand<TResponse> : IRequest<Response<TResponse>>;
