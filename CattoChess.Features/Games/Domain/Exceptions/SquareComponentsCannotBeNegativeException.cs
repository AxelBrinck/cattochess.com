using CattoChess.Core;
using CattoChess.Features.Games.Domain.ValueObjects;

namespace CattoChess.Features.Games.Domain.Exceptions;

public sealed class SquareComponentsCannotBeNegativeException : DomainException
{
    public SquareComponentsCannotBeNegativeException(Square square) :
        base($"Square {square.ToString()} is not valid, as it has negative " +
            "components")
    {

    }
}