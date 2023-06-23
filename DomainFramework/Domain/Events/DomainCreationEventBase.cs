using DomainFramework.DataProviders.Id;
using DomainFramework.DataProviders.Time;

namespace DomainFramework.Domain.Events;

public abstract record DomainCreationEventBase<TAggregateId, TEventId> : DomainEventBase<TEventId>
    where TAggregateId : struct
    where TEventId : struct
{
    public TAggregateId AggregateId { get; }

    public DomainCreationEventBase(
        TAggregateId aggregateId,
        string fullyQualifiedEventClassName,
        IIdProvider<TEventId> idProvider,
        ITimeProvider timeProvider
    ) : base(idProvider, timeProvider) =>
        AggregateId = aggregateId;

    public DomainCreationEventBase(
        TAggregateId aggregateId,
        string fullyQualifiedEventClassName,
        TEventId id,
        DateTime timestamp
    ) : base(id, timestamp) =>
        AggregateId = aggregateId;
}