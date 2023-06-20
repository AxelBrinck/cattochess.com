using EventSourcingFramework.Domain.DataProviders;

namespace EventSourcingFramework.Domain.Events;

public abstract record CreationEvent<TAggregateId, TEventId> : Event<TEventId>
    where TAggregateId : struct
    where TEventId : struct
{
    public TAggregateId AggregateId { get; }

    public CreationEvent(
        TAggregateId aggregateId,
        string fullyQualifiedEventClassName,
        IIdProvider<TEventId> idProvider,
        ITimeProvider timeProvider
    ) : base(idProvider, timeProvider) =>
        AggregateId = aggregateId;

    public CreationEvent(
        TAggregateId aggregateId,
        string fullyQualifiedEventClassName,
        TEventId id,
        DateTime timestamp
    ) : base(id, timestamp) =>
        AggregateId = aggregateId;
}