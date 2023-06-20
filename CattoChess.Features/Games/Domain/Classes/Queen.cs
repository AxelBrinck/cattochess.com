using CattoChess.Features.Games.Domain.ValueObjects;

namespace CattoChess.Features.Games.Domain.Classes;

public sealed class Queen : ChessPiece
{
    public Queen(Player owner, Square square, Orientation orientation) :
        base(owner, square, orientation, gameEndsIfDies: false)
    {

    }

    protected override bool TryMove(Square to, ChessBoard chessBoard)
    {
        return true;
    }
}