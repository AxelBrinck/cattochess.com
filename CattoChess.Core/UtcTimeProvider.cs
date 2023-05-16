namespace CattoChess.Core;

public sealed class UtcTimeProvider : ITimeProvider
{
    public DateTime GetCurrentTime() => DateTime.UtcNow;
}