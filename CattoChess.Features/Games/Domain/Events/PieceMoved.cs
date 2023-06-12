using CattoChess.Core.Domain;
using CattoChess.Features.Games.Domain.ValueObjects;

namespace CattoChess.Features.Games.Domain.Events;

public sealed record PieceMoved(
    Guid EventId,
    DateTime Timestamp,
    string FullyQualifiedAggregateClassName,
    Square From,
    Square To
) : IEvent;