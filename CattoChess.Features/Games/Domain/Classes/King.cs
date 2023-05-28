using CattoChess.Features.Games.Domain.ValueObjects;

namespace CattoChess.Features.Games.Domain.Classes;

public sealed class King : ChessPiece
{
    public King(Player owner, Square square) :
        base(owner, square, gameEndsIfDies: true)
    {

    }

    protected override bool TryMove(Square to, ChessBoard chessBoard)
    {
        return true;
    }
}