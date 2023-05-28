using CattoChess.Core;
using CattoChess.Features.Games.Domain.ValueObjects;

namespace CattoChess.Features.Games.Domain.Exceptions;

public sealed class SquareAlreadyOccupiedException : DomainException
{
    public SquareAlreadyOccupiedException(Square square) :
        base($"Square {square.ToString()} is already occupied.")
    {
        
    }
}