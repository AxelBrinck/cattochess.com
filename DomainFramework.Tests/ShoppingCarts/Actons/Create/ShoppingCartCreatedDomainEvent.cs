using DomainFramework.DataProviders.Id;
using DomainFramework.DataProviders.Time;
using DomainFramework.Domain.Events;

namespace DomainFramework.Tests.ShoppingCarts.Actons.Create;

public sealed record ShoppingCartCreatedDomainEvent : DomainCreationEventBase
{
    public ShoppingCartCreatedDomainEvent(
        Guid aggregateId,
        string fullyQualifiedEventClassName,
        IIdProvider<Guid> idProvider,
        ITimeProvider timeProvider
    ) : base(aggregateId, fullyQualifiedEventClassName, idProvider, timeProvider)
    {

    }

    public ShoppingCartCreatedDomainEvent(
        Guid aggregateId,
        string fullyQualifiedEventClassName,
        Guid id,
        DateTime timestamp
    ) : base(aggregateId, fullyQualifiedEventClassName, id, timestamp)
    {
        
    }
}