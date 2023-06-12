namespace CattoChess.Core.Domain;

public interface IReadOnlytAggregateMetadata<TId>  where TId : struct 
{
    TId AggregateId { get; }
    DateTime CreationTimestamp { get; }
    DateTime? DeletionTimestamp { get; }
    DateTime LastEventTimestamp { get; }
}