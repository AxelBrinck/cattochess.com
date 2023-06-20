using EventSourcingFramework;
using CattoChess.Features.Games.Domain.ValueObjects;

namespace CattoChess.Features.Games.Domain.Exceptions;

public sealed class InvalidMoveException : DomainException
{
    public InvalidMoveException(Square from, Square to) : 
        base($"Piece at {from.ToString()} canot move to {to.ToString()}")
    {

    }
}