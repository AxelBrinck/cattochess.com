namespace CattoChess.Core.Domain;

public abstract class Aggregate<TAggregateId, TEventId, TState>
    where TEventId : struct
    where TAggregateId : struct
    where TState : class, new()
{
    protected TState State { get; } = new();

    private readonly AggregateMetadata<TAggregateId, TEventId> metadata;
    private readonly CommandHandlerRouter<TAggregateId, TEventId, TState> eventHandlerRouter = new();
    private readonly Queue<(Event<TEventId> Event, int ExpectedVersion)> uncommitedEvents = new();

    public Aggregate(CreationEvent<TAggregateId, TEventId> creationEvent)
    {
        metadata = new AggregateMetadata<TAggregateId, TEventId>(creationEvent);

        OnRegisterEventHandlers(eventHandlerRouter);
    }

    protected abstract void OnRegisterEventHandlers(
        ICommandHandlerRegistrator<TAggregateId, TEventId, TState> registrator
    );
}