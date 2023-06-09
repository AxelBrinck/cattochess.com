using CattoChess.Features.Games.Domain.Exceptions;

namespace CattoChess.Features.Games.Domain.ValueObjects;

public sealed record Square
{
    public int X { get; }
    public int Y { get; }

    public Square(int x, int y)
    {
        if (x < 0 || y < 0)
            throw new SquareComponentsCannotBeNegativeException(square: this);
        
        X = x;
        Y = y;
    }

    public static DistanceDetails operator- (Square a, Square b) => 
        new DistanceDetails(a.X - b.X, a.Y - a.Y); 

    public override string ToString() => $"[{X}, {Y}]";
}