using CattoChess.Core.Domain.DataProviders;
using CattoChess.Core.Domain.Events;
using CattoChess.Features.Games.Domain.ValueObjects;

namespace CattoChess.Features.Games.Domain.Events.MovePiece;

public sealed record PieceMoved : Event<Guid>
{
    public Square From { get; }
    public Square To { get; }

    public PieceMoved(
        Square from,
        Square to,
        IIdProvider<Guid> idProvider,
        ITimeProvider timeProvider
    ) : base(idProvider, timeProvider)
    {
        From = from;
        To = to;
    }

    public PieceMoved(
        Square from,
        Square to,
        Guid id,
        DateTime timestamp
    ) : base(id, timestamp)
    {
        From = from;
        To = to;
    }
}