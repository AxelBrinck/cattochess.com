using DomainFramework.Domain.Events;

namespace DomainFramework.Domain.Commands;

public interface ICommandHandler<TCommand, TEventId, TState, TAggregateId>
    where TCommand : ICommand
    where TEventId : struct
    where TState : class
    where TAggregateId : struct
{
    public static IEnumerable<EventBase<TEventId>> Handle(
        TCommand command,
        TState state,
        IReadOnlytAggregateMetadata<TAggregateId> metadata)
    {
        throw new NotImplementedException();
    }
}