namespace CattoChess.Core.Domain.DataProviders;

public sealed class GuidIdProvider : IIdProvider<Guid>
{
    public Guid NewId() => Guid.NewGuid();
}