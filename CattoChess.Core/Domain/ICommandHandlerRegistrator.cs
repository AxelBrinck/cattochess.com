namespace CattoChess.Core.Domain;

public interface ICommandHandlerRegistrator<TAggregateId, TEventId, TState>
    where TAggregateId : struct
    where TEventId : struct
    where TState : class
{
    void RegisterCommandHandler<TCommand, TCommandHandler, TEvent>()
        where TCommand : ICommand
        where TCommandHandler : ICommandHandler<TAggregateId, TEventId, TState, TEvent>
        where TEvent : Event<TEventId>;
}