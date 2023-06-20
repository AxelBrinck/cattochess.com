namespace EventSourcingFramework.Domain.Events;

public interface IEventApplier<TAggregateId, TEventId, TState, TEvent>
    where TAggregateId : struct
    where TEventId : struct
    where TState : class
    where TEvent : Event<TEventId>
{
    void Handle(
        TEvent @event,
        TState state,
        IReadOnlytAggregateMetadata<TAggregateId> metadata
    );
}