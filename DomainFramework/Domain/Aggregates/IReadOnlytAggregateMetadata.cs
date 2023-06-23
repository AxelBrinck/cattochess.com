namespace DomainFramework.Domain.Aggregates;

public interface IReadOnlytAggregateMetadata<TAggregateId>  where TAggregateId : struct 
{
    TAggregateId AggregateId { get; }
    DateTime CreationTimestamp { get; }
    DateTime? DeletionTimestamp { get; }
    DateTime LastEventTimestamp { get; }
}