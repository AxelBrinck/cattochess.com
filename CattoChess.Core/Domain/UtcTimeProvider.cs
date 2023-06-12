namespace CattoChess.Core.Domain;

public sealed class UtcTimeProvider : ITimeProvider
{
    public DateTime GetCurrentTime() => DateTime.UtcNow;
}