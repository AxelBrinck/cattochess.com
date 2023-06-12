using CattoChess.Core.Exceptions;

namespace CattoChess.Core.Domain;

public sealed class CommandHandlerRouter<TAggregateId, TEventId, TState> : 
    ICommandHandlerRegistrator<TAggregateId, TEventId, TState>
    where TAggregateId : struct
    where TEventId : struct
    where TState : class
{
    private List<string> handlers = new();

    public void RegisterCommandHandler<TCommand, TEventHandler, TEvent>()
        where TCommand : ICommand
        where TEvent : Event<TEventId>
        where TEventHandler : ICommandHandler<TAggregateId, TEventId, TState, TEvent>
    {
        var fullyQualifiedEventClassName = typeof(TEventHandler).FullName ??
            throw new CouldNotGetEventClassFullNameException();
        
        if (handlers.Contains(fullyQualifiedEventClassName)) throw new EventHandlerAlreadyRegisteredException();

        handlers.Add(fullyQualifiedEventClassName);
    }

    internal void Apply<TEvent>(TEvent @event) where TEvent : Event<TEventId>
    {
        var fullyQualifiedEventClassName = typeof(TEvent).FullName ??
            throw new CouldNotGetEventClassFullNameException();

        if (!handlers.Contains(fullyQualifiedEventClassName)) throw new NoEventHandlerFoundForGivenEventException();

        var eventHandler = Type.GetType(fullyQualifiedEventClassName);
    }
}