using CattoChess.Core.Domain.Exceptions;
using CattoChess.Core.Exceptions;

namespace CattoChess.Core.Domain.Events;

public sealed class CommandHandlerRouter<TAggregateId, TEventId, TState> : 
    IEventHandlerRegistrator<TAggregateId, TEventId, TState>
    where TAggregateId : struct
    where TEventId : struct
    where TState : class
{
    private Dictionary<Type, Type> handlers = new();

    public void RegisterCommandHandler<TEventHandler, TEvent>()
        where TEvent : Event<TEventId>
        where TEventHandler : IEventHandler<TAggregateId, TEventId, TState, TEvent>, new()
    {
        var eventType = typeof(TEvent);

        if (handlers.ContainsKey(eventType)) throw new EventHandlerAlreadyRegisteredException();

        handlers.Add(eventType, typeof(TEventHandler));
    }

    internal void Apply<TEvent>(TEvent @event) where TEvent : Event<TEventId>
    {
        var eventType = typeof(TEvent);

        if (!handlers.ContainsKey(eventType))
            throw new NoEventHandlerFoundForGivenEventException();

        var handlerType = handlers[eventType];
        
        var handler = Activator.CreateInstance(handlerType) ??
            throw new CouldNotInstantiateEventHandlerException();
    }
}