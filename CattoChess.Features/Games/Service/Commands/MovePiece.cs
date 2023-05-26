namespace CattoChess.Features.Games.Service.Commands;

public sealed record MovePiece(
    Guid GameId,
    int FromX,
    int FromY,
    int ToX,
    int ToY
);