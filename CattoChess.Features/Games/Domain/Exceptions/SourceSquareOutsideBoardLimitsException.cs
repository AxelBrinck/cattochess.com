using EventSourcingFramework;
using CattoChess.Features.Games.Domain.ValueObjects;

namespace CattoChess.Features.Games.Domain.Exceptions;

public sealed class SourceSquareOutsideBoardLimitsException : DomainException
{
    public SourceSquareOutsideBoardLimitsException(Square square) : 
        base($"Given source position {square.ToString()} is outside board" +
        " limits.")
    {
        
    }
}