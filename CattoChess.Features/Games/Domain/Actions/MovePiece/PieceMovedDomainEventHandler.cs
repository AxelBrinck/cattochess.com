using DomainFramework.Domain.Aggregates;
using DomainFramework.Domain.Events;

namespace CattoChess.Features.Games.Domain.Actions.MovePiece;

public sealed class PieceMovedDomainEventHandler :
    IDomainEventHandler<Guid, Guid, PieceMovedDomainEvent, GameAggregateState>
{
    public static void Handle(
        PieceMovedDomainEvent input,
        GameAggregateState state,
        IReadOnlytAggregateMetadata<Guid> metadata
    )
    {
        throw new NotImplementedException();
    }
}