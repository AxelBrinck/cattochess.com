namespace EventSourcingFramework.Domain;

public interface IReadOnlytAggregateMetadata<TAggregateId>  where TAggregateId : struct 
{
    TAggregateId AggregateId { get; }
    DateTime CreationTimestamp { get; }
    DateTime? DeletionTimestamp { get; }
    DateTime LastEventTimestamp { get; }
}