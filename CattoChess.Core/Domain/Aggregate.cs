using CattoChess.Core.Domain.Exceptions;

namespace CattoChess.Core.Domain;

public abstract class Aggregate<TId, TEntity> : IReadOnlytAggregateMetadata<TId>
    where TEntity : class, new()
    where TId : struct
{
    public TEntity Entity { get; } = new();

    public TId Id { get; }
    public DateTime CreationTimestamp { get; }
    public DateTime? DeletionTimestamp { get; }
    public DateTime LastModificationTimestamp { get; }
    public int Version { get; private set; } = 0;

    private List<IEventHandler<TId, TEntity>> eventHandlers = new();
    private Queue<(IEvent Event, int ExpectedVersion)> uncommitedEvents = new();

    public Aggregate(ICreationEvent<TId> creationEvent)
    {

    }

    protected void RegisterEventHandler<TEvent>(
        IEventHandler<TId, TEntity, TEvent> eventHandler
    ) where TEvent : IEvent
    {
        if (eventHandlers.Any(x => x.Event is TEvent))
            throw new EventHandlerAlreadyRegisteredException();

        eventHandlers.Add(eventHandler);
    }

    protected void Apply<TEvent>(
        IEventHandler<TId, TEntity, TEvent> handler,
        TEvent @event
    ) where TEvent : IEvent
    {
        handler = (IEventHandler<TId, TEntity, TEvent>) 
            eventHandlers.First(x => x.Event is TEvent);

        var events = handler.Handle(@event, Entity, this);

        foreach(var e in events)
        {
            uncommitedEvents.Append((e, Version));

            Version++;
        }
    }
    
}