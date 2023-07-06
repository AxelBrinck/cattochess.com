using DomainFramework.DataProviders.Id;
using DomainFramework.DataProviders.Time;
using DomainFramework.Domain.Aggregates;
using DomainFramework.Domain.Events;
using DomainFramework.Tests.ShoppingCarts.Actons.AddItem.Exceptions;

namespace DomainFramework.Tests.ShoppingCarts.Actons.AddItem;

public sealed class AddItemDomainCommandHandler :
    IDomainCommandHandler<AddItemDomainCommand, ShoppingCartAggregateState>
{
    public static IEnumerable<IDomainEvent<Guid>> Handle(
        AddItemDomainCommand input,
        ShoppingCartAggregateState state,
        IReadOnlytAggregateMetadata<Guid> metadata,
        IIdProvider<Guid> idProvider,
        ITimeProvider timeProvider
    )
    {
        if (input.ItemName != input.ItemName.Trim())
            throw new ItemNameIsNotTrimmedException(input.ItemName);

        if (input.ItemName != input.ItemName.ToLower())
            throw new ItemNameIsNotLowerCaseException(input.ItemName);
        
        if (state.Items.Contains(input.ItemName))
            throw new ItemNameIsAlreadyAddedException(input.ItemName);
        
        yield return new ItemAddedDomainEvent(
            idProvider.NewId(),
            timeProvider.GetCurrentTime(),
            input.ItemName
        );
    }
}