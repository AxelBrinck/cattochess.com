namespace CattoChess.Core.Domain;

public interface IRepository<TAggregateId, TEventId, TState>
    where TAggregateId : struct
    where TEventId : struct
    where TState : class, new()
{
    void Insert(Aggregate<TAggregateId, TEventId, TState> aggregate);
    void Update(Aggregate<TAggregateId, TEventId, TState> aggregate);
}