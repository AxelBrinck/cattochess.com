namespace CattoChess.Features.Games.Domain.Classes;

public sealed class Pawn : ChessPiece
{
    public Pawn(Player owner, int positionX, int positionY) : 
        base(owner, nameof(Pawn), positionX, positionY, gameEndsIfDies: false)
    {

    }

    protected override bool TryMove(int x, int y)
    {
        
        return true;
    }
}