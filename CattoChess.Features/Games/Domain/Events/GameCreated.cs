using CattoChess.Core.Domain;

namespace CattoChess.Features.Games.Domain.Events;

public sealed record GameCreated : ICreationEvent<Guid>
{
    public Guid AggregateId => throw new NotImplementedException();

    public string FullyQualifiedAggregateClassName => throw new NotImplementedException();

    public Guid Id => throw new NotImplementedException();

    public DateTime Timestamp => throw new NotImplementedException();
}