namespace EventSourcingFramework.Domain.DataProviders;

public interface IIdProvider<TId> where TId : struct
{
    TId NewId();
}