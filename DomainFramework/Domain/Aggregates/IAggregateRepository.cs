namespace DomainFramework.Domain.Aggregates;

public interface IAggregateRepository<TAggregateId, TEventId, TAggreateState>
    where TAggregateId : struct
    where TEventId : struct
    where TAggreateState : class, ICloneable, new()
{
    ValueTask<AggregateBase<TAggregateId, TEventId, TAggreateState>?> GetByIdAsync(TAggregateId id);
    ValueTask InsertAsync(AggregateBase<TAggregateId, TEventId, TAggreateState> aggregate);
    ValueTask UpdateAsync(AggregateBase<TAggregateId, TEventId, TAggreateState> aggregate);
}