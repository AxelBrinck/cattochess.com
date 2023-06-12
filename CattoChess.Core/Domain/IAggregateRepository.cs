namespace CattoChess.Core.Domain;

public interface IAggregateRepository<TAggregateId, TEventId, TState>
    where TAggregateId : struct
    where TEventId : struct
    where TState : class, new()
{
    Aggregate<TAggregateId, TEventId, TState>? GetById(TAggregateId id);
    void Insert(Aggregate<TAggregateId, TEventId, TState> aggregate);
    void Update(Aggregate<TAggregateId, TEventId, TState> aggregate);
}