using DomainFramework.Domain.Handlers;

namespace DomainFramework.Domain.Events;

public interface IDomainEventHandler<TAggregateId, TEventId, TAggregateState>
    where TAggregateId : struct
    where TEventId : struct
    where TAggregateState : class, ICloneable
{

}

public interface IDomainEventHandler<TAggregateId, TEventId, TCommand, TAggregateState> : 
    IHandler<TAggregateId, TCommand, TAggregateState>,
    IDomainEventHandler<TAggregateId, TEventId, TAggregateState>
    where TAggregateId : struct
    where TEventId : struct
    where TCommand : DomainEventBase<TEventId>
    where TAggregateState : class, ICloneable
{

}