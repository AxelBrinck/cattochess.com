using CattoChess.Core.Domain;

namespace CattoChess.Features.Games.Domain.Events;

public sealed class MovePiece : IEventHandler<Guid, Game, PieceMoved>
{
    public IEnumerable<IEvent> AssertValid(
        PieceMoved @event,
        Game entity,
        IReadOnlytAggregateMetadata<Guid> aggregateMetadata
    )
    {
        throw new NotImplementedException();
    }

    public IEnumerable<IEvent> Apply(
        PieceMoved @event,
        Game entity,
        IReadOnlytAggregateMetadata<Guid> aggregateMetadata
    )
    {
        throw new NotImplementedException();
    }
}