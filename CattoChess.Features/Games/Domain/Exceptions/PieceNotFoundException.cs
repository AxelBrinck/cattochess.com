using DomainFramework;
using CattoChess.Features.Games.Domain.ValueObjects;

namespace CattoChess.Features.Games.Domain.Exceptions;

public sealed class PieceNotFoundException : DomainException
{
    public PieceNotFoundException(Square square) : 
        base($"There was no piece found at given location: " +
            $"{square.ToString()}.")
    {

    }
}