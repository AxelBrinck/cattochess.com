using CattoChess.Core;

namespace CattoChess.Features.Games.Domain.Events;

public sealed record GameCreated : DomainEvent
{
    public Guid Id { get; }

    public GameCreated(
        Guid id,
        ITimeProvider timeProvider
    ) : base(timeProvider) =>
        Id = id;

    public GameCreated(
        Guid id,
        DateTime timestamp
    ) : base(timestamp) =>
        Id = id;
}