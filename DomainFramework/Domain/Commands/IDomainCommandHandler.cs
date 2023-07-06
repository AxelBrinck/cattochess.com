using DomainFramework.DataProviders.Id;
using DomainFramework.DataProviders.Time;
using DomainFramework.Domain.Aggregates;
using DomainFramework.Domain.Commands;

namespace DomainFramework.Domain.Events;

public interface IDomainCommandHandler
{

}

public interface IDomainCommandHandler<TAggregateId, TCommand, TAggregateState, TEventId> :
    IDomainCommandHandler
    where TAggregateId : struct
    where TCommand : class, IDomainCommand
    where TAggregateState : class, ICloneable
    where TEventId : struct
{
    static abstract IEnumerable<IDomainEvent<TEventId>> Handle(
        TCommand input,
        TAggregateState state,
        IReadOnlytAggregateMetadata<TAggregateId> metadata,
        IIdProvider<TAggregateId> idProvider,
        ITimeProvider timeProvider
    );
}

public interface IDomainCommandHandler<TCommand, TAggregateState> :
    IDomainCommandHandler<Guid, TCommand, TAggregateState, Guid>
    where TCommand : class, IDomainCommand
    where TAggregateState : class, ICloneable
{

}