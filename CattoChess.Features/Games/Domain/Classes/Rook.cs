using CattoChess.Features.Games.Domain.ValueObjects;

namespace CattoChess.Features.Games.Domain.Classes;

public sealed class Rook : ChessPiece
{
    public Rook(Player owner, Square square) :
        base(owner, square, gameEndsIfDies: false)
    {

    }

    protected override bool TryMove(Square to, ChessBoard chessBoard)
    {
        return true;
    }
}