using DomainFramework.Domain.Events;
using CattoChess.Features.Games.Domain.ValueObjects;
using DomainFramework.DataProviders.Id;
using DomainFramework.DataProviders.Time;

namespace CattoChess.Features.Games.Domain.Actions.MovePiece;

public sealed record PieceMovedDomainEvent : DomainEventBase<Guid>
{
    public Square From { get; }
    public Square To { get; }

    public PieceMovedDomainEvent(
        Square from,
        Square to,
        IIdProvider<Guid> idProvider,
        ITimeProvider timeProvider
    ) : base(idProvider, timeProvider)
    {
        From = from;
        To = to;
    }

    public PieceMovedDomainEvent(
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