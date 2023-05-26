namespace CattoChess.Core;

public abstract record DomainEvent
{
    public DateTime Timestamp { get; }

    public DomainEvent(ITimeProvider timeProvider) =>
        Timestamp = timeProvider.GetCurrentTime();
    
    public DomainEvent(DateTime timestamp) =>
        Timestamp = timestamp;
}