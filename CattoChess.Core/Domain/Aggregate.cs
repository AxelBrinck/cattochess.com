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
    private readonly Queue<object> uncommittedEvents = new();

    public Aggregate(CreationEvent<TAggregateId, TEventId> creationEvent, bool enqueueEvent)
    {
        metadata = new AggregateMetadata<TAggregateId, TEventId>(creationEvent);

        OnRegisterEventHandlers(eventHandlerRouter);

        if (enqueueEvent)
            uncommittedEvents.Append(creationEvent);
    }

    protected abstract void OnRegisterEventHandlers(
        IEventHandlerRegistrator<TAggregateId, TEventId, TState> registrator
    );

    public IEnumerable<object> DequeueAllUncommitedEvents()
    {
        while(uncommittedEvents.TryDequeue(out var @event))
            yield return @event;
    }

    public bool CanEventBeApplied<TEvent>(TEvent @event, out Exception? reason)
        where TEvent : Event<TEventId>
    {
        var eventHandler = eventHandlerRouter.GetEventHandlerInstance<TEvent>();

        try
        {
            eventHandler.PassBusinessLogic(@event, State, metadata);
        }
        catch(DomainException exception)
        {
            reason = exception;
            return false;
        }

        reason = null;
        return true;
    }

    public void ApplyNewEvent<TEvent>(TEvent @event) where TEvent : Event<TEventId>
    {
        var eventHandler = eventHandlerRouter.GetEventHandlerInstance<TEvent>();
        
        eventHandler.PassBusinessLogic(@event, State, metadata);
        eventHandler.Apply(@event, State, metadata);

        uncommittedEvents.Append(@event);
    }

    public void ApplyDirectly<TEvent>(TEvent @event) where TEvent : Event<TEventId>
    {
        var eventHandler = eventHandlerRouter.GetEventHandlerInstance<TEvent>();

        eventHandler.Apply(@event, State, metadata);
    }
}