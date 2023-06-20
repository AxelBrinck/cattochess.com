namespace EventSourcingFramework.Domain.DataProviders;

public sealed class UtcTimeProvider : ITimeProvider
{
    public DateTime GetCurrentTime() => DateTime.UtcNow;
}