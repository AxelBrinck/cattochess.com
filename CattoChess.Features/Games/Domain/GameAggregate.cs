using CattoChess.Core.Domain;
using CattoChess.Core.Domain.DataProviders;
using CattoChess.Core.Domain.Events;
using CattoChess.Features.Games.Domain.Classes;
using CattoChess.Features.Games.Domain.Events;
using CattoChess.Features.Games.Domain.Events.MovePiece;
using CattoChess.Features.Games.Domain.ValueObjects;

namespace CattoChess.Features.Games.Domain;

public sealed class GameAggregate : Aggregate<Guid, Guid, GameState>
{
    public GameAggregate(GameCreated creationEvent, bool enqueueEvent = false) : 
        base(creationEvent, enqueueEvent) =>
        State.Board = creationEvent.Board;

    public static GameAggregate CreateStandardGame(
        GameId gameId,
        IIdProvider<Guid> idProvider,
        ITimeProvider timeProvider
    ) =>
        new GameAggregate(
            new GameCreated(
                gameId,
                ChessBoard.CreateStandardBoard(),
                typeof(GameAggregate).FullName ?? throw new Exception(),
                idProvider,
                timeProvider
            ), 
            enqueueEvent: true
        );

    protected override void OnRegisterEventHandlers(
        IEventHandlerRegistrator<Guid, Guid, GameState> registrator
    )
    {
        registrator.RegisterEventHandler<MovingPiece, PieceMoved>();
    }
}