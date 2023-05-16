using CattoChess.Core.Exceptions;

namespace CattoChess.Domain.Accounts.ValueObjects;

public sealed record AccountId
{
    public Guid Value { get; }

    public AccountId(Guid value)
    {
        if (Value == Guid.Empty)
            throw new EmptyGuidException($"{nameof(AccountId)} value " +
            "requires to be non-empty.");
        
        Value = value;
    }

    public static implicit operator Guid(AccountId x) => x.Value;
    public static implicit operator AccountId(Guid x) => new(x);
}