using DomainFramework.Domain;
using DomainFramework.Domain.Events;
using CattoChess.Features.Games.Domain.Events;
using CattoChess.Features.Games.Domain.Events.MovePiece;

namespace CattoChess.Features.Games.Domain;

public sealed class GameAggregate : AggregateBase<Guid, Guid, GameState>
{
    public GameAggregate(GameCreated creationEvent, bool enqueueCreationEvent = false) : 
        base(creationEvent, enqueueCreationEvent) =>
        State.Board = creationEvent.Board;

    protected override void OnRegisterEventHandlers(
        IEventHandlerRegistrator<Guid, Guid, GameState> registrator
    )
    {
        registrator.RegisterEventHandler<MovingPiece, PieceMoved>();
    }
}