using EventSourcingFramework.Domain.Events;

namespace EventSourcingFramework.Domain;

public sealed class AggregateMetadata<TAggregateId, TEventId> : IReadOnlytAggregateMetadata<TAggregateId>
    where TAggregateId : struct
    where TEventId : struct
{
    public TAggregateId AggregateId { get; set; }
    public DateTime CreationTimestamp { get; set;  }
    public DateTime? DeletionTimestamp { get; set;  }
    public DateTime LastEventTimestamp { get; set; }

    internal AggregateMetadata(CreationEventBase<TAggregateId, TEventId> creationEvent)
    {
        AggregateId = creationEvent.AggregateId;
        CreationTimestamp = creationEvent.Timestamp;
        LastEventTimestamp = creationEvent.Timestamp;
    }
}