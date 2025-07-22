namespace Ordering.Domain.Abstractions;

using MediatR;

public interface IDomainEvent : INotification
{
    Guid EventId => Guid.NewGuid();

    DateTime OccuredOn => DateTime.Now;

    string EventName =>
        GetType()?.AssemblyQualifiedName ?? string.Empty;
}
