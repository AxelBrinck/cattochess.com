namespace CattoChess.Core.Domain.Events;

public interface IEventHandlerRegistrator<TAggregateId, TEventId, TState>
    where TAggregateId : struct
    where TEventId : struct
    where TState : class
{
    void RegisterCommandHandler<TEventHandler, TEvent>()
        where TEventHandler : IEventHandler<TAggregateId, TEventId, TState, TEvent>, new()
        where TEvent : Event<TEventId>;
}