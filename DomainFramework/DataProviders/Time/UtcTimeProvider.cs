namespace DomainFramework.DataProviders.Time;

public sealed class UtcTimeProvider : ITimeProvider
{
    public DateTime GetCurrentTime() => DateTime.UtcNow;
}