using CattoChess.Core.Domain;

namespace CattoChess.Features.Games.Domain.Events.MovingPiece;

public sealed class MovingPiece : ICommandHandler<Guid, Guid, GameState, PieceMoved>
{
    public IEnumerable<Event<Guid>> AssertValid(
        PieceMoved @event,
        GameState entity,
        IReadOnlytAggregateMetadata<Guid> aggregateMetadata
    )
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Event<Guid>> Apply(
        PieceMoved @event,
        GameState entity,
        IReadOnlytAggregateMetadata<Guid> aggregateMetadata
    )
    {
        throw new NotImplementedException();
    }
}