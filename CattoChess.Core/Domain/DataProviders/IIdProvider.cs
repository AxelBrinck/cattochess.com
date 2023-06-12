namespace CattoChess.Core.Domain.DataProviders;

public interface IIdProvider<TId> where TId : struct
{
    TId NewId();
}