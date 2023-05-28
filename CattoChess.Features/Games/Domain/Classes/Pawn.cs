using CattoChess.Features.Games.Domain.ValueObjects;

namespace CattoChess.Features.Games.Domain.Classes;

public sealed class Pawn : ChessPiece
{
    public Pawn(Player owner, Square square) : 
        base(owner, square, gameEndsIfDies: false)
    {

    }

    protected override bool TryMove(Square toSquare, ChessBoard chessBoard)
    {
        if (Owner == Player.White)
        {

        }
        
        if (Owner == Player.Black)
        {

        }

        return true;
    }
}