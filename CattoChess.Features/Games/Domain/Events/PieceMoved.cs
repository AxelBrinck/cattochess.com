using CattoChess.Core;
using CattoChess.Features.Games.Domain.ValueObjects;

namespace CattoChess.Features.Games.Domain.Events;

public sealed record PieceMoved : DomainEvent<Guid>
{
    public Square From { get; }
    public Square To { get; }

    public PieceMoved(
        Game game,
        ITimeProvider timeProvider,
        Square from,
        Square to
    ) : base(game, timeProvider)
    {
        From = from;
        To = to;
    }

    public PieceMoved(
        Guid id,
        int version,
        DateTime timestamp,
        Square from,
        Square to
    ) : base(id, version, timestamp)
    {
        From = from;
        To = to;
    }
}