using CattoChess.Core.Exceptions;

namespace CattoChess.Features.Board.Domain.ValueObjects;

public sealed record BoardId
{
    public Guid Value { get; }

    public BoardId(Guid value)
    {
        if (Value == Guid.Empty)
            throw new EmptyGuidException($"{nameof(BoardId)} value " +
            "requires to be non-empty.");
            
        Value = value;
    }

    public static implicit operator BoardId(Guid x) => x;
    public static implicit operator Guid(BoardId x) => x.Value;
}