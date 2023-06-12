using CattoChess.Core.Exceptions;

namespace CattoChess.Core.Domain;

public sealed class EventHandlerRouter<TId, TEntity> : IEventHandlerRegistrator<TId, TEntity>
    where TId : struct
    where TEntity : class
{
    private List<string> handlers = new();

    public void RegisterEventHandler<TEventHandler, TEvent>()
        where TEvent : IEvent
        where TEventHandler : IEventHandler<TId, TEntity, TEvent>
    {
        var fullyQualifiedEventClassName = typeof(TEventHandler).FullName ??
            throw new CouldNotGetEventClassFullNameException();
        
        if (handlers.Contains(fullyQualifiedEventClassName)) throw new EventHandlerAlreadyRegisteredException();

        handlers.Add(fullyQualifiedEventClassName);
    }

    internal void Apply<TEvent>(TEvent @event) where TEvent : IEvent
    {
        var fullyQualifiedEventClassName = typeof(TEvent).FullName ??
            throw new CouldNotGetEventClassFullNameException();

        if (!handlers.Contains(fullyQualifiedEventClassName)) throw new NoEventHandlerFoundForGivenEventException();

        var eventHandler = Type.GetType(fullyQualifiedEventClassName);
    }
}