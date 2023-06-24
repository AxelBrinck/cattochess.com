using DomainFramework.Domain.Aggregates;
using DomainFramework.Domain.Commands;
using DomainFramework.Domain.Events;
using DomainFramework.Tests.ShoppingCarts.Actons.Create;
using DomainFramework.Utils;

namespace DomainFramework.Tests.ShoppingCarts;

public sealed class ShoppingCartAggregate : AggregateBase<ShoppingCartAggregateState>
{
    public ShoppingCartAggregate(
        ShoppingCartCreatedDomainEvent creationEvent,
        bool enqueueCreationEvent
    ) : base(creationEvent, enqueueCreationEvent)
    {

    }
    
    protected override void OnRegisterCommandHandlers(
        TypeMapper<IDomainCommand, IDomainCommandHandler> mapper
    )
    {
        throw new NotImplementedException();
    }

    protected override void OnRegisterEventHandlers(
        TypeMapper<DomainEventBase<Guid>, IDomainEventHandler> mapper
    )
    {
        throw new NotImplementedException();
    }
}