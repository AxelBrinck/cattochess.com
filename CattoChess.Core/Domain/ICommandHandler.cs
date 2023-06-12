namespace CattoChess.Core.Domain;

public interface ICommandHandler<TAggregateId, TEventId, TState, TEvent>
    where TAggregateId : struct
    where TEventId : struct
    where TState : class
    where TEvent : Event<TEventId>
{
    IEnumerable<Event<TEventId>> AssertValid(
        TEvent @event,
        TState state,
        IReadOnlytAggregateMetadata<TAggregateId> aggregateMetadata
    );

    IEnumerable<Event<TEventId>> Apply(
        TEvent @event,
        TState state,
        IReadOnlytAggregateMetadata<TAggregateId> aggregateMetadata
    );
}