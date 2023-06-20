namespace CattoChess.Features.Games.Domain.ValueObjects;

public sealed record DistanceDetails(int X, int Y)
{

    public int SquaresAway => Math.Abs(X > Y ? X : Y);
}