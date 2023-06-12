namespace CattoChess.Core.Domain;

public sealed class AggregateMetadata<TId> : IReadOnlytAggregateMetadata<TId> where TId : struct 
{
    public TId AggregateId { get; set; }
    public DateTime CreationTimestamp { get; set;  }
    public DateTime? DeletionTimestamp { get; set;  }
    public DateTime? LastModificationTimestamp { get; set; }

    public AggregateMetadata(ICreationEvent<TId> creationEvent)
    {
        AggregateId = creationEvent.AggregateId;
        CreationTimestamp = creationEvent.Timestamp;
    }
}