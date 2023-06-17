namespace CattoChess.Core.Domain.Events;

public interface IEventHandler<TAggregateId, TEventId, TState, TEvent>
    where TAggregateId : struct
    where TEventId : struct
    where TState : class
    where TEvent : Event<TEventId>
{
    void PassBusinessLogic(
        TEvent @event,
        TState stateClone,
        IReadOnlytAggregateMetadata<TAggregateId> metadata
    );

    IEnumerable<Event<TEventId>> Apply(
        TEvent @event,
        TState state,
        IReadOnlytAggregateMetadata<TAggregateId> metadata
    );
}