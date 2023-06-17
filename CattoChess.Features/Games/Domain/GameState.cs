using CattoChess.Features.Games.Domain.Classes;

namespace CattoChess.Features.Games.Domain;

public sealed class GameState
{
    public ChessBoard? Board { get; set; }
}