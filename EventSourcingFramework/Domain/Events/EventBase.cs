using EventSourcingFramework.DataProviders.Id;
using EventSourcingFramework.DataProviders.Time;

namespace EventSourcingFramework.Domain.Events;

public abstract record EventBase<TEventId> where TEventId : struct
{
    public TEventId Id { get; }
    public DateTime Timestamp { get; }

    public EventBase(IIdProvider<TEventId> idProvider, ITimeProvider timeProvider)
    {
        Id = idProvider.NewId();
        Timestamp = timeProvider.GetCurrentTime();
    }

    public EventBase(TEventId id, DateTime timestamp)
    {
        Id = id;
        Timestamp = timestamp;
    }
}