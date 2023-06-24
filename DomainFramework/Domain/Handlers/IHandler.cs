using DomainFramework.Domain.Aggregates;

namespace DomainFramework.Domain.Handlers;

public interface IHandler<TAggregateId, TInput, TAggregateState>
    where TAggregateId : struct
    where TAggregateState : class, ICloneable
{
    static abstract void Handle(
        TInput input,
        TAggregateState state,
        IReadOnlytAggregateMetadata<TAggregateId> metadata
    );
}