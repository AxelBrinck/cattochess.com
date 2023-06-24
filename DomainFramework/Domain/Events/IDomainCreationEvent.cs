namespace DomainFramework.Domain.Events;

public interface IDomainCreationEvent<TAggregateId, TEventId> : IDomainEvent<TAggregateId>
    where TAggregateId : struct
    where TEventId : struct
{
    TAggregateId AggregateId { get; }
    string AggregateStreamName { get; }
}