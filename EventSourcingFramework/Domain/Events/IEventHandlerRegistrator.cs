namespace EventSourcingFramework.Domain.Events;

public interface IEventHandlerRegistrator<TAggregateId, TEventId, TState>
    where TAggregateId : struct
    where TEventId : struct
    where TState : class
{
    void RegisterEventHandler<TEventHandler, TEvent>()
        where TEventHandler : IEventApplier<TAggregateId, TEventId, TState, TEvent>, new()
        where TEvent : EventBase<TEventId>;
}