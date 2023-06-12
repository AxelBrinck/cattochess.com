using CattoChess.Core.Domain;
using CattoChess.Core.Domain.DataProviders;
using CattoChess.Core.Domain.Events;
using CattoChess.Features.Games.Domain.Events;
using CattoChess.Features.Games.Domain.Events.MovePiece;
using CattoChess.Features.Games.Domain.ValueObjects;

namespace CattoChess.Features.Games.Domain;

public sealed class GameAggregate : Aggregate<Guid, Guid, GameState>
{
    public GameAggregate(GameCreated creationEvent) : base(creationEvent)
    {

    }

    public static GameAggregate CreateStandardGame(
        GameId gameId,
        IIdProvider<Guid> idProvider,
        ITimeProvider timeProvider
    )
    {
        var @event = new GameCreated(
            gameId,
            typeof(GameAggregate).FullName ?? throw new Exception(),
            idProvider,
            timeProvider);
        
        var aggregate = new GameAggregate(@event);

        return aggregate;
    }

    protected override void OnRegisterEventHandlers(
        IEventHandlerRegistrator<Guid, Guid, GameState> registrator
    )
    {
        registrator.RegisterCommandHandler<MovingPiece, PieceMoved>();
    }
}