using EventSourcingFramework;
using CattoChess.Features.Games.Domain.ValueObjects;

namespace CattoChess.Features.Games.Domain.Exceptions;

public sealed class TargetSquareOutsideBoardLimitsException : DomainException
{
    public TargetSquareOutsideBoardLimitsException(Square square) : 
        base($"Given target square {square.ToString()} is outside board" +
        " limits.")
    {
        
    }
}