using DomainFramework.Domain.Aggregates;
using DomainFramework.Domain.Events;

namespace CattoChess.Features.Games.Domain.Actions.MovePiece;

public sealed class MovePieceDomainCommandHandler :
    IDomainCommandHandler<Guid, MovePieceDomainCommand, GameAggregateState>
{
    public static void Handle(
        MovePieceDomainCommand input,
        GameAggregateState state,
        IReadOnlytAggregateMetadata<Guid> metadata
    )
    {
        throw new NotImplementedException();
    }
}