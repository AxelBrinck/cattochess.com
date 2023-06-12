namespace CattoChess.Core.Domain;

public interface ITimeProvider
{
    DateTime GetCurrentTime();
}