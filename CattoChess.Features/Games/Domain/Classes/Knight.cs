using CattoChess.Features.Games.Domain.ValueObjects;

namespace CattoChess.Features.Games.Domain.Classes;

public sealed class Knight : ChessPiece
{
    public Knight(Player owner, Square square) :
        base(owner, square, gameEndsIfDies: false)
    {

    }

    protected override bool TryMove(Square to, ChessBoard chessBoard)
    {
        return true;
    }
}