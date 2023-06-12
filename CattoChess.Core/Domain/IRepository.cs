namespace CattoChess.Core.Domain;

public interface IRepository<TId, TEntity>
    where TId : struct
    where TEntity : class, new()
{
    void Insert(Aggregate<TId, TEntity> aggregate);
    void Update(Aggregate<TId, TEntity> aggregate);
}