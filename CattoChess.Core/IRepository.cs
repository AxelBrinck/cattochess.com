namespace CattoChess.Core;

public interface IRepository<TAggregateRoot, TId>
    where TAggregateRoot : AggregateRoot<TId>
    where TId : struct
{
    ValueTask<TAggregateRoot> GetById(TId id);
    ValueTask Insert(TAggregateRoot aggregate);
    ValueTask Update(TAggregateRoot entity);
    ValueTask DeleteById(TId id);
}