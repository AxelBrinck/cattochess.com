namespace DomainFramework.Domain.Aggregates;

public interface IReadOnlytAggregateMetadata<TAggregateId>  where TAggregateId : struct 
{
    TAggregateId AggregateId { get; }
    DateTime CreationTimestamp { get; }
    DateTime LastEventTimestamp { get; }
    int Version { get; }
}