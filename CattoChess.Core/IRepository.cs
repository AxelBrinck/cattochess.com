namespace CattoChess.Core;

public interface IRepository<TEntity, TId>
{
    ValueTask<TEntity> GetById(TId id);
    ValueTask Insert(TEntity entity);
    ValueTask Update(TEntity entity);
    ValueTask DeleteById(TId id);
}