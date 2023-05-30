namespace CattoChess.Core.Domain;

public interface IAggregateMetadata<TId> : IReadOnlytAggregateMetadata<TId>
    where TId : struct 
{
    new TId Id { get; set; }
    new DateTime CreationTimestamp { get; set; }
    new DateTime? DeletionTimestamp { get; set; }
    new DateTime LastModificationTimestamp { get; set; }
    new int Version { get; set; }
}