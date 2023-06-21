using DomainFramework.Exceptions;

namespace CattoChess.Features.Games.Domain.ValueObjects;

public sealed record GameId
{
    public Guid Value { get; }

    public GameId(Guid value)
    {
        if (Value == Guid.Empty)
            throw new EmptyGuidException($"{nameof(GameId)} value " +
            "requires to be non-empty.");
            
        Value = value;
    }

    public static implicit operator GameId(Guid x) => x;
    public static implicit operator Guid(GameId x) => x.Value;
}