using DomainFramework.Domain.Aggregates;
using DomainFramework.Domain.Events;

namespace DomainFramework.Tests.ShoppingCarts.Actons.AddItem;

public sealed class ItemAddedDomainEventHandler :
    IDomainEventHandler<ItemAddedDomainEvent, ShoppingCartAggregateState>
{
    public static void Handle(
        ItemAddedDomainEvent input,
        ShoppingCartAggregateState state,
        IReadOnlytAggregateMetadata<Guid> metadata
    )
    {
        state.Items.Add(input.ItemName);
    }
}