using CattoChess.Features.Games.Domain.Exceptions;
using CattoChess.Features.Games.Domain.ValueObjects;

namespace CattoChess.Features.Games.Domain.Classes;

public sealed class ChessBoard
{
    public int Width { get; }
    public int Height { get; }
    
    private readonly List<ChessPiece> pieces = new();

    private ChessBoard(int width, int height)
    {
        Width = width;
        Height = height;
    }

    private static int StandardBoardWidth = 8;
    private static int StandardBoardHeight = 8;

    public static ChessBoard CreateStandardBoard()
    {
        var chessBoard = new ChessBoard(StandardBoardWidth, StandardBoardHeight);

        for (var x = 0; x < 8; x++)
            chessBoard.AddChessPiece(new Pawn(Player.White, new Square(x, 1)));
        chessBoard.AddChessPiece(new Rook(Player.White, new Square(0, 0)));
        chessBoard.AddChessPiece(new Rook(Player.White, new Square(7, 0)));
        chessBoard.AddChessPiece(new Knight(Player.White, new Square(1, 0)));
        chessBoard.AddChessPiece(new Knight(Player.White, new Square(6, 0)));
        chessBoard.AddChessPiece(new Bishop(Player.White, new Square(2, 0)));
        chessBoard.AddChessPiece(new Bishop(Player.White, new Square(5, 0)));
        chessBoard.AddChessPiece(new Queen(Player.White, new Square(3, 0)));
        chessBoard.AddChessPiece(new King(Player.White, new Square(4, 0)));
        
        for (var x = 0; x < 8; x++)
            chessBoard.AddChessPiece(new Pawn(Player.Black, new Square(x, 6)));
        chessBoard.AddChessPiece(new Rook(Player.Black, new Square(0, 7)));
        chessBoard.AddChessPiece(new Rook(Player.Black, new Square(7, 7)));
        chessBoard.AddChessPiece(new Knight(Player.Black, new Square(1, 7)));
        chessBoard.AddChessPiece(new Knight(Player.Black, new Square(6, 7)));
        chessBoard.AddChessPiece(new Bishop(Player.Black, new Square(2, 7)));
        chessBoard.AddChessPiece(new Bishop(Player.Black, new Square(5, 7)));
        chessBoard.AddChessPiece(new Queen(Player.Black, new Square(3, 7)));
        chessBoard.AddChessPiece(new King(Player.Black, new Square(4, 7)));

        return chessBoard;
    }

    private void AddChessPiece(ChessPiece chessPiece)
    {
        if (IsSquareOccupied(chessPiece.Square))
            throw new SquareAlreadyOccupiedException(chessPiece.Square);
        
        pieces.Add(chessPiece);
    }

    public bool IsSquareOccupied(Square square) =>
        pieces.Any(piece => piece.Square == square);

    public bool DoesSquareExists(Square square) =>
        square.X < Width && square.Y < Height;
    
    public void AssertPieceAbilityToMove(Square from, Square to)
    {
        if (!DoesSquareExists(from))
            throw new TargetSquareOutsideBoardLimitsException(from);

        if (!IsSquareOccupied(from))
            throw new PieceNotFoundException(from);
        
        if (!DoesSquareExists(to))
            throw new TargetSquareOutsideBoardLimitsException(to);
        
        var isMoveLegal = pieces.First(piece => 
            piece.Square == from
        ).IsMoveLegal(to, chessBoard: this);

        if (!isMoveLegal)
            throw new InvalidMoveException(from, to);
    }

    internal void MovePiece(Square from, Square to)
    {
        AssertPieceAbilityToMove(from, to);
        
        pieces.First(piece =>
            piece.Square == from
        ).Move(to, chessBoard: this);
    }
}