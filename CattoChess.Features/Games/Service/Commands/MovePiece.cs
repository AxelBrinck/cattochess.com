using CattoChess.Features.Games.Domain.ValueObjects;

namespace CattoChess.Features.Games.Service.Commands;

public sealed record MovePiece(
    Guid GameId,
    Square From,
    Square To
);