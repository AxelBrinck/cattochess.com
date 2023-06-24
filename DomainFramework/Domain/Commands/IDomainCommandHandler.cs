using DomainFramework.Domain.Commands;
using DomainFramework.Domain.Handlers;

namespace DomainFramework.Domain.Events;

public interface IDomainCommandHandler
{

}

public interface IDomainCommandHandler<TAggregateId, TCommand, TAggregateState> : 
    IHandler<TAggregateId, TCommand, TAggregateState>,
    IDomainCommandHandler
    where TAggregateId : struct
    where TCommand : class, IDomainCommand
    where TAggregateState : class, ICloneable
{
    
}