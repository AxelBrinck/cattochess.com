namespace CattoChess.Core.Domain;

public abstract record Event<TId> : IEvent<TId> where TId : struct
{
    public TId Id { get; }
    public DateTime Timestamp { get; }

    public Event(IIdProvider<TId> idProvider, ITimeProvider timeProvider)
    {
        Id = idProvider.NewId();
        Timestamp = timeProvider.GetCurrentTime();
    }

    public Event(TId id, DateTime timestamp)
    {
        Id = id;
        Timestamp = timestamp;
    }
}