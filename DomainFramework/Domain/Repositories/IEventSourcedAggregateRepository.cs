using DomainFramework.Domain.Aggregates;

namespace DomainFramework.Domain.Repositories;

public interface IEventSourcedAggregateRepository<TAggregateId, TEventId, TAggreateState, TAggregate> :
    IAggregateRepository<TAggregateId, TEventId, TAggreateState, TAggregate>
    where TAggregateId : struct
    where TEventId : struct
    where TAggreateState : class, ICloneable, new()
    where TAggregate : AggregateBase<TAggregateId, TEventId, TAggreateState>
{
    ValueTask<TAggregate?> GetByIdAsync(TAggregateId id, int version);
    ValueTask<TAggregate?> GetByIdAsync(TAggregateId id, DateTime time);
}