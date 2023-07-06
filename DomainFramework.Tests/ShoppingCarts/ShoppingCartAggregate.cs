using DomainFramework.Domain.Aggregates;
using DomainFramework.Domain.Commands;
using DomainFramework.Domain.Events;
using DomainFramework.Tests.ShoppingCarts.Actons.AddItem;
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
        mapper.DefineMap<AddItemDomainCommand, AddItemDomainCommandHandler>();
    }

    protected override void OnRegisterEventHandlers(
        TypeMapper<IDomainEvent<Guid>, IDomainEventHandler> mapper
    )
    {
        mapper.DefineMap<ItemAddedDomainEvent, ItemAddedDomainEventHandler>();
    }
}