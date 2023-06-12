namespace CattoChess.Core.Domain;

public abstract class Aggregate<TId, TEntity>
    where TEntity : class, new()
    where TId : struct
{
    public TEntity Entity { get; } = new();

    private readonly AggregateMetadata<TId> metadata;
    private readonly EventHandlerRouter<TId, TEntity> eventHandlerManager = new();
    private readonly Queue<(IEvent Event, int ExpectedVersion)> uncommitedEvents = new();

    public Aggregate(ICreationEvent<TId> creationEvent)
    {
        metadata = new AggregateMetadata<TId>(creationEvent);

        OnRegisterEventHandlers(eventHandlerManager);
    }

    protected abstract void OnRegisterEventHandlers(IEventHandlerRegistrator<TId, TEntity> registrator);
}