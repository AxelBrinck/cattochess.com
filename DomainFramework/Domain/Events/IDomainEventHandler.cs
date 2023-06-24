using DomainFramework.Domain.Handlers;

namespace DomainFramework.Domain.Events;

public interface IDomainEventHandler
{

}

public interface IDomainEventHandler<TAggregateId, TEventId, TEvent, TAggregateState> : 
    IHandler<TAggregateId, TEvent, TAggregateState>,
    IDomainEventHandler
    where TAggregateId : struct
    where TEventId : struct
    where TEvent : DomainEventBase<TEventId>
    where TAggregateState : class, ICloneable
{

}