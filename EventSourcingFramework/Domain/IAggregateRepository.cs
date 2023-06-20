namespace EventSourcingFramework.Domain;

public interface IAggregateRepository<TAggregateId, TEventId, TState>
    where TAggregateId : struct
    where TEventId : struct
    where TState : class, new()
{
    AggregateBase<TAggregateId, TEventId, TState>? GetById(TAggregateId id);
    void Insert(AggregateBase<TAggregateId, TEventId, TState> aggregate);
    void Update(AggregateBase<TAggregateId, TEventId, TState> aggregate);
}