namespace DomainFramework.DataProviders.Id;

public sealed class GuidIdProvider : IIdProvider<Guid>
{
    public Guid NewId() => Guid.NewGuid();
}