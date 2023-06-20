using EventSourcingFramework.Domain.Events;

namespace EventSourcingFramework.Domain.Commands;

public interface ICommandHandler<TCommand, TEventId, TState, TAggregateId>
    where TCommand : ICommand
    where TEventId : struct
    where TState : class
    where TAggregateId : struct
{
    public IEnumerable<Event<TEventId>> Handle(
        TCommand command,
        TState state,
        IReadOnlytAggregateMetadata<TAggregateId> metadata)
    {
        throw new NotImplementedException();
    }
}