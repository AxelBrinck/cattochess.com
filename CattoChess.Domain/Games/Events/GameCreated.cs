using CattoChess.Core;

namespace CattoChess.Domain.Games.Events;

public sealed record GameCreated : DomainEvent
{
    public Guid Id { get; }
    public Guid AccountCreatorId { get; }

    public GameCreated(
        Guid id,
        Guid accountCreatorId,
        ITimeProvider timeProvider
    ) : base(timeProvider)
    {
        Id = id;
        AccountCreatorId = accountCreatorId;
    }

    public GameCreated(
        Guid id,
        Guid accountCreatorId,
        DateTime timestamp
    ) : base(timestamp)
    {
        Id = id;
        AccountCreatorId = accountCreatorId;
    }
}