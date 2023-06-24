namespace DomainFramework.Domain.Events;

public interface IDomainEvent<TEventId> where TEventId : struct
{
    TEventId EventId { get; }
    DateTime Timestamp { get; }
}