namespace DomainFramework.Domain.Events;

public interface IEventApplier<TAggregateId, TEventId, TState, TEvent>
    where TAggregateId : struct
    where TEventId : struct
    where TState : class
    where TEvent : EventBase<TEventId>
{
    static void Handle(
        TEvent @event,
        TState state,
        IReadOnlytAggregateMetadata<TAggregateId> metadata
    )
    {
        throw new NotImplementedException();
    }
}