namespace CattoChess.Core.Domain;

public interface IIdProvider<TId> where TId : struct
{
    TId NewId();
}