using DomainFramework.Domain.Commands;

namespace DomainFramework.Tests.ShoppingCarts.Actons.AddItem;

public sealed record AddItemDomainCommand(
    string ItemName
) : IDomainCommand;