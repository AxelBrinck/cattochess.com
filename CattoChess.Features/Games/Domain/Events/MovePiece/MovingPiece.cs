using CattoChess.Core.Domain;
using CattoChess.Core.Domain.Events;

namespace CattoChess.Features.Games.Domain.Events.MovePiece;

public sealed class MovingPiece : IEventHandler<Guid, Guid, GameState, PieceMoved>
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