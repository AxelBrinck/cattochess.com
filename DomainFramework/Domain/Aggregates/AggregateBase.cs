using DomainFramework.Domain.Commands;
using DomainFramework.Domain.Events;
using DomainFramework.Utils;

namespace DomainFramework.Domain.Aggregates;

public abstract class AggregateBase<TAggregateId, TEventId, TAggregateState> :
    IReadOnlytAggregateMetadata<TAggregateId>
    where TEventId : struct
    where TAggregateId : struct
    where TAggregateState : class, ICloneable, new()
{
    protected TAggregateState State { get; } = new();

    public TAggregateId AggregateId { get; }
    public DateTime CreationTimestamp { get; }
    public DateTime LastEventTimestamp { get; private set; }
    public int Version { get; private set; }

    private readonly Queue<object> uncommittedEvents = new();
    private readonly TypeMapper<IDomainCommand, IDomainCommandHandler> commandHandlers = new();
    private readonly TypeMapper<IDomainEvent<TEventId>, IDomainEventHandler> eventHandlers = new();

    public AggregateBase(
        IDomainCreationEvent<TAggregateId, TEventId> creationEvent,
        bool enqueueCreationEvent
    )
    {
        AggregateId = creationEvent.AggregateId;
        CreationTimestamp = creationEvent.Timestamp;
        LastEventTimestamp = creationEvent.Timestamp;

        OnRegisterCommandHandlers(commandHandlers);
        OnRegisterEventHandlers(eventHandlers);

        if (enqueueCreationEvent)
            uncommittedEvents.Append(creationEvent);
    }

    protected abstract void OnRegisterCommandHandlers(
        TypeMapper<IDomainCommand, IDomainCommandHandler> mapper);

    protected abstract void OnRegisterEventHandlers(
        TypeMapper<IDomainEvent<TEventId>, IDomainEventHandler> mapper);

    public IEnumerable<object> DequeueAllUncommitedEvents()
    {
        while(uncommittedEvents.TryDequeue(out var @event))
            yield return @event;
    }

    public void ApplyCommand<TDomainCommand>(TDomainCommand command)
        where TDomainCommand : IDomainCommand
    {
        var handler = commandHandlers.Map<TDomainCommand>();
    }
}

public abstract class AggregateBase<TAggregateState> : AggregateBase<Guid, Guid, TAggregateState>
    where TAggregateState : class, ICloneable, new()
{
    public AggregateBase(
        IDomainCreationEvent<Guid, Guid> creationEvent,
        bool enqueueCreationEvent
    ) : base(creationEvent, enqueueCreationEvent)
    {

    }
}