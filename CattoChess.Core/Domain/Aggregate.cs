using CattoChess.Core.Domain.Events;

namespace CattoChess.Core.Domain;

public abstract class Aggregate<TAggregateId, TEventId, TState>
    where TEventId : struct
    where TAggregateId : struct
    where TState : class, new()
{
    protected TState State { get; } = new();

    private readonly AggregateMetadata<TAggregateId, TEventId> metadata;
    private readonly CommandHandlerRouter<TAggregateId, TEventId, TState> eventHandlerRouter = new();
    private readonly Queue<object> uncommitedEvents = new();

    public Aggregate(CreationEvent<TAggregateId, TEventId> creationEvent)
    {
        metadata = new AggregateMetadata<TAggregateId, TEventId>(creationEvent);

        uncommitedEvents.Append(creationEvent);

        OnRegisterEventHandlers(eventHandlerRouter);
    }

    protected abstract void OnRegisterEventHandlers(
        IEventHandlerRegistrator<TAggregateId, TEventId, TState> registrator
    );
}