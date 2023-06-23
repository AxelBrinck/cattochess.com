using DomainFramework.DataProviders.Id;
using DomainFramework.DataProviders.Time;

namespace DomainFramework.Domain.Events;

public abstract record DomainEventBase<TEventId> where TEventId : struct
{
    public TEventId Id { get; }
    public DateTime Timestamp { get; }

    public DomainEventBase(IIdProvider<TEventId> idProvider, ITimeProvider timeProvider)
    {
        Id = idProvider.NewId();
        Timestamp = timeProvider.GetCurrentTime();
    }

    public DomainEventBase(TEventId id, DateTime timestamp)
    {
        Id = id;
        Timestamp = timestamp;
    }
}