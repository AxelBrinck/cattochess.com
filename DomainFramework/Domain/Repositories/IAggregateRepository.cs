using DomainFramework.Domain.Aggregates;

namespace DomainFramework.Domain.Repositories;

public interface IAggregateRepository<TAggregateId, TEventId, TAggreateState, TAggregate>
    where TAggregateId : struct
    where TEventId : struct
    where TAggreateState : class, ICloneable, new()
    where TAggregate : AggregateBase<TAggregateId, TEventId, TAggreateState>
{
    ValueTask<TAggregate?> GetByIdAsync(TAggregateId id);
    ValueTask InsertAsync(TAggregate aggregate);
    ValueTask UpdateAsync(TAggregate aggregate);
}