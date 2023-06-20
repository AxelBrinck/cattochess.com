namespace EventSourcingFramework.Domain.Events;

public interface IEventApplier<TAggregateId, TEventId, TState, TEvent>
    where TAggregateId : struct
    where TEventId : struct
    where TState : class
    where TEvent : Event<TEventId>
{
    void AssertBusinessLogicRequirementsMet(
        TEvent @event,
        TState stateClone,
        IReadOnlytAggregateMetadata<TAggregateId> metadata
    );

    void ApplyEvent(
        TEvent @event,
        TState state,
        IReadOnlytAggregateMetadata<TAggregateId> metadata
    );
}