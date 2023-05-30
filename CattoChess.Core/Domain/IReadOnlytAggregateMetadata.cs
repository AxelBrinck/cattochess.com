namespace CattoChess.Core.Domain;

public interface IReadOnlytAggregateMetadata<TId>  where TId : struct 
{
    TId Id { get; }
    DateTime CreationTimestamp { get; }
    DateTime? DeletionTimestamp { get; }
    DateTime LastModificationTimestamp { get; }
    int Version { get; }
}