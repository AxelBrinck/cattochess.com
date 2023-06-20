using EventSourcingFramework.Domain.DataProviders;

namespace EventSourcingFramework.Domain.Events;

public abstract record Event<TEventId> where TEventId : struct
{
    public TEventId Id { get; }
    public DateTime Timestamp { get; }

    public Event(IIdProvider<TEventId> idProvider, ITimeProvider timeProvider)
    {
        Id = idProvider.NewId();
        Timestamp = timeProvider.GetCurrentTime();
    }

    public Event(TEventId id, DateTime timestamp)
    {
        Id = id;
        Timestamp = timestamp;
    }
}