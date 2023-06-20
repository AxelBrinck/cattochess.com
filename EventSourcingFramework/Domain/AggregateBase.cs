using System.Text.Json;
using EventSourcingFramework.Domain.Events;
using EventSourcingFramework.Domain.Exceptions;

namespace EventSourcingFramework.Domain;

public abstract class AggregateBase<TAggregateId, TEventId, TState>
    where TEventId : struct
    where TAggregateId : struct
    where TState : class, new()
{
    protected TState State { get; } = new();

    private readonly AggregateMetadata<TAggregateId, TEventId> metadata;
    private readonly EventHandlerRouter<TAggregateId, TEventId, TState> eventHandlerRouter = new();
    private readonly Queue<object> uncommittedEvents = new();

    public AggregateBase(CreationEvent<TAggregateId, TEventId> creationEvent, bool enqueueCreationEvent)
    {
        metadata = new AggregateMetadata<TAggregateId, TEventId>(creationEvent);

        OnRegisterEventHandlers(eventHandlerRouter);

        if (enqueueCreationEvent)
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

        var serializedState = JsonSerializer.Serialize(@event);
        var clonedState = JsonSerializer.Deserialize<TState>(serializedState) ??
            throw new UnableToCloneAggregateStateException();

        try
        {
            eventHandler.AssertBusinessLogicRequirementsMet(@event, clonedState, metadata);
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
        
        eventHandler.AssertBusinessLogicRequirementsMet(@event, State, metadata);
        eventHandler.ApplyEvent(@event, State, metadata);

        uncommittedEvents.Append(@event);
    }

    public void ApplyDirectly<TEvent>(TEvent @event) where TEvent : Event<TEventId>
    {
        var eventHandler = eventHandlerRouter.GetEventHandlerInstance<TEvent>();

        eventHandler.ApplyEvent(@event, State, metadata);
    }
}