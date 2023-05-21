namespace CattoChess.Features.Pieces.Domain.ValueObjects;

public sealed record PieceId
{
    public Guid Value { get; }

    public PieceId(Guid value)
    {

    }

    public static implicit operator PieceId(Guid x) => new(x);
    public static implicit operator Guid(PieceId x) => x.Value;
}