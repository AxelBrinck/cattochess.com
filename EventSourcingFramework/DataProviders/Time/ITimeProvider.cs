namespace EventSourcingFramework.DataProviders.Time;

public interface ITimeProvider
{
    DateTime GetCurrentTime();
}