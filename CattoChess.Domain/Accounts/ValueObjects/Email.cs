namespace CattoChess.Domain.Accounts.ValueObjects;

public sealed record Email
{
    public string Value { get; }

    public Email(string value)
    {
        Value = value;
    }

    public static implicit operator string(Email x) => x.Value;
    public static implicit operator Email(string x) => new(x);
}