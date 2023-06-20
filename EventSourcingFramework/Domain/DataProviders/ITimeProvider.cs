namespace EventSourcingFramework.Domain.DataProviders;

public interface ITimeProvider
{
    DateTime GetCurrentTime();
}