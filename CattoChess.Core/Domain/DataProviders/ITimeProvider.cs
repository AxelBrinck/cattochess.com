namespace CattoChess.Core.Domain.DataProviders;

public interface ITimeProvider
{
    DateTime GetCurrentTime();
}