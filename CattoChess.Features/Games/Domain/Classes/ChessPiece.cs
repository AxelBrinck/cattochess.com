using CattoChess.Features.Games.Domain.Exceptions;

namespace CattoChess.Features.Games.Domain.Classes;

public abstract class ChessPiece
{
    public string PieceName { get; }
    public Player Owner { get; }
    public int PositionX { get; private set; }
    public int PositionY { get; private set; }
    public int TimesMoved { get; private set; }
    public bool GameEndsIfDies { get; }

    public ChessPiece(
        Player owner,
        string pieceName,
        int positionX,
        int positionY,
        bool gameEndsIfDies)
    {
        Owner = owner;
        PieceName = pieceName;
        PositionX = positionX;
        PositionY = positionY;
        GameEndsIfDies = gameEndsIfDies;
    }

    protected abstract bool TryMove(int x, int y);

    public void MoveTo(int x, int y)
    {
        if (!TryMove(x, y))
            throw new InvalidTargetPositionException($"Piece {PieceName} " +
                $" cannot move to {x}, {y}.");

        PositionX = x;
        PositionY = y;
        TimesMoved++;
    }
}