using DomainFramework.Domain.Aggregates;

namespace DomainFramework.Domain.Events;

public interface IDomainEventHandler
{

}

public interface IDomainEventHandler<TAggregateId, TEventId, TEvent, TAggregateState> :
    IDomainEventHandler
    where TAggregateId : struct
    where TEventId : struct
    where TEvent : IDomainEvent<TEventId>
    where TAggregateState : class, ICloneable
{
    static abstract void Handle(
        TEvent input,
        TAggregateState state,
        IReadOnlytAggregateMetadata<TAggregateId> metadata
    );
}

public interface IDomainEventHandler<TEvent, TAggregateState> :
    IDomainEventHandler<Guid, Guid, TEvent, TAggregateState>
    where TEvent : IDomainEvent<Guid>
    where TAggregateState : class, ICloneable
{
    
}