using CattoChess.Features.Games.Domain.Exceptions;
using CattoChess.Features.Games.Domain.ValueObjects;

namespace CattoChess.Features.Games.Domain.Classes;

public abstract class ChessPiece
{
    public Player Owner { get; }
    public Square Square { get; private set; }
    public Orientation Orientation { get; }
    public int TimesMoved { get; private set; }
    public bool GameEndsIfDies { get; }

    public ChessPiece(
        Player owner,
        Square square,
        Orientation orientation,
        bool gameEndsIfDies)
    {
        Owner = owner;
        Square = square;
        Orientation = orientation;
        GameEndsIfDies = gameEndsIfDies;
    }

    protected abstract bool TryMove(Square to, ChessBoard chessBoard);

    public void Move(Square to, ChessBoard chessBoard)
    {
        if (!TryMove(to, chessBoard))
            throw new InvalidMoveException(Square, to);

        Square = to;
        
        TimesMoved++;
    }

    internal bool IsMoveLegal(
        Square to,
        ChessBoard chessBoard
    ) => TryMove(to, chessBoard);
}