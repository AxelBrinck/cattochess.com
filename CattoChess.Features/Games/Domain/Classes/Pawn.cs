using CattoChess.Features.Games.Domain.ValueObjects;

namespace CattoChess.Features.Games.Domain.Classes;

public sealed class Pawn : ChessPiece
{
    public Pawn(Player owner, Square square, Orientation orientation) : 
        base(owner, square, orientation, gameEndsIfDies: false)
    {

    }

    protected override bool TryMove(Square toSquare, ChessBoard chessBoard)
    {
        var moveOffset = toSquare - Square;

        if (Owner == Player.White)
        {

        }
        
        if (Owner == Player.Black)
        {

        }

        return true;
    }
}