namespace DomainFramework.DataProviders.Id;

public interface IIdProvider<TId> where TId : struct
{
    TId NewId();
}