namespace Shared.CQRS;

using MediatR;

public interface ICommand : IRequest<Unit>;

public interface ICommand<out TResponse> : IRequest<TResponse>;
