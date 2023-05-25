using CattoChess.Core.Exceptions;

namespace CattoChess.Features.GridBoards.Domain.ValueObjects;

public sealed record GridBoardId
{
    public Guid Value { get; }

    public GridBoardId(Guid value)
    {
        if (Value == Guid.Empty)
            throw new EmptyGuidException($"{nameof(GridBoardId)} value " +
            "requires to be non-empty.");
            
        Value = value;
    }

    public static implicit operator GridBoardId(Guid x) => x;
    public static implicit operator Guid(GridBoardId x) => x.Value;
}