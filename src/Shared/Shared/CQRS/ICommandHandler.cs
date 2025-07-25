namespace Shared.CQRS;

using MediatR;
using Models;

public interface ICommandHandler<in TCommand>
    : IRequestHandler<TCommand, Response<Unit>>
    where TCommand : ICommand;

public interface ICommandHandler<in TCommand, TResponse>
    : IRequestHandler<TCommand, Response<TResponse>>
    where TCommand : ICommand<TResponse>
    where TResponse : notnull;
