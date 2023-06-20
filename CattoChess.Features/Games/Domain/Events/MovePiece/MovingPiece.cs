using EventSourcingFramework.Domain;
using EventSourcingFramework.Domain.Events;

namespace CattoChess.Features.Games.Domain.Events.MovePiece;

public sealed class MovingPiece : IEventApplier<Guid, Guid, GameState, PieceMoved>
{
    public void AssertBusinessLogicRequirementsMet(
        PieceMoved @event,
        GameState stateClone,
        IReadOnlytAggregateMetadata<Guid> metadata
    ) =>
        stateClone.Board.AssertPieceAbilityToMove(@event.From, @event.To);

    public void Handle(
        PieceMoved @event,
        GameState state,
        IReadOnlytAggregateMetadata<Guid> metadata
    ) =>
        state.Board.MovePiece(@event.From, @event.To);
}