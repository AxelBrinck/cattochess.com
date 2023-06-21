using DomainFramework.DataProviders.Id;
using DomainFramework.DataProviders.Time;

namespace DomainFramework.Domain.Events;

public abstract record CreationEventBase<TAggregateId, TEventId> : EventBase<TEventId>
    where TAggregateId : struct
    where TEventId : struct
{
    public TAggregateId AggregateId { get; }

    public CreationEventBase(
        TAggregateId aggregateId,
        string fullyQualifiedEventClassName,
        IIdProvider<TEventId> idProvider,
        ITimeProvider timeProvider
    ) : base(idProvider, timeProvider) =>
        AggregateId = aggregateId;

    public CreationEventBase(
        TAggregateId aggregateId,
        string fullyQualifiedEventClassName,
        TEventId id,
        DateTime timestamp
    ) : base(id, timestamp) =>
        AggregateId = aggregateId;
}