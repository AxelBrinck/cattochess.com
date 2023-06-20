using CattoChess.Features.Games.Domain.ValueObjects;

namespace CattoChess.Features.Games.Domain.Classes;

public sealed class Bishop : ChessPiece
{
    public Bishop(Player owner, Square square, Orientation orientation) :
        base(owner, square, orientation, gameEndsIfDies: false)
    {

    }

    protected override bool TryMove(Square toSquare, ChessBoard chessBoard)
    {
        throw new NotImplementedException();
    }
}