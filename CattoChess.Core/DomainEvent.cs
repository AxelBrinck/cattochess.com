namespace CattoChess.Core;

public abstract record DomainEvent<TId> where TId : struct
{
    public TId AggregateRootId { get; }
    public DateTime Timestamp { get; }
    public int Version { get; }

    public DomainEvent(
        AggregateRoot<TId> aggregateRoot,
        ITimeProvider timeProvider)
    {
        AggregateRootId = aggregateRoot.Id;
        Version = aggregateRoot.Version;
        Timestamp = timeProvider.GetCurrentTime();
    }
    
    public DomainEvent(
        TId aggregateRoot,
        int version,
        DateTime timestamp)
    {
        AggregateRootId = aggregateRoot;
        Version = version;
        Timestamp = timestamp;
    }
}