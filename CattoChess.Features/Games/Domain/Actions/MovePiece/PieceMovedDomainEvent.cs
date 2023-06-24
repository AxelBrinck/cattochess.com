using DomainFramework.Domain.Events;
using CattoChess.Features.Games.Domain.ValueObjects;

namespace CattoChess.Features.Games.Domain.Actions.MovePiece;

public sealed record PieceMovedDomainEvent(
    Guid EventId,
    DateTime Timestamp,
    Square From,
    Square To
) : IDomainEvent<Guid>;