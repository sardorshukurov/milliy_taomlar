namespace Shared.Messaging.Events;

public record IntegrationEvent
{
    public Guid Id => Guid.NewGuid();

    public DateTime OccurredOn => DateTime.UtcNow;

    public string EventType => GetType().Name;
}
