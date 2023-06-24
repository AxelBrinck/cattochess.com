using DomainFramework.Domain.Events;

namespace DomainFramework.Tests.ShoppingCarts.Actons.Create;

public sealed record ShoppingCartCreatedDomainEvent(
    Guid EventId,
    Guid AggregateId,
    string AggregateStreamName,
    DateTime Timestamp
) : IDomainCreationEvent<Guid, Guid>;