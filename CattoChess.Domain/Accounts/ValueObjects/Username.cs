namespace CattoChess.Domain.Accounts.ValueObjects;

public sealed record Username
{
    public string Value { get; }

    public Username(string value)
    {
        Value = value;
    }

    public static implicit operator string(Username x) => x.Value;
    public static implicit operator Username(string x) => new(x);
}