using DomainFramework.Domain.Events;

namespace DomainFramework.Tests.ShoppingCarts.Actons.AddItem;

public sealed record ItemAddedDomainEvent(
    Guid EventId,
    DateTime Timestamp,
    string ItemName
) : IDomainEvent<Guid>;