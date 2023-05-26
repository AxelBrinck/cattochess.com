using CattoChess.Core;

namespace CattoChess.Features.Games.Domain.Exceptions;

public sealed class InvalidTargetPositionException : DomainException
{
    public InvalidTargetPositionException(string reason) : base(reason)
    {

    }
}