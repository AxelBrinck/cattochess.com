namespace CattoChess.Core;

public interface IEventSourcedRepository<TAggregateRoot, TId> :
    IRepository<TAggregateRoot, TId>
        where TAggregateRoot : AggregateRoot<TId>
        where TId : struct
{
    ValueTask<TAggregateRoot> GetById(TId id, int version);
    ValueTask<TAggregateRoot> GetById(TId id, DateTime time);
}