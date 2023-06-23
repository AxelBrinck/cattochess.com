using CattoChess.Features.Games.Domain.Classes;

namespace CattoChess.Features.Games.Domain;

public sealed class GameAggregateState : ICloneable
{
    public ChessBoard Board { get; set; } = default!;

    public object Clone()
    {
        return 0;
    }
}