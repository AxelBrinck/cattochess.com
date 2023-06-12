using CattoChess.Core.Domain;
using CattoChess.Features.Games.Domain.Events;
using CattoChess.Features.Games.Domain.Events.MovingPiece;
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

        // TODO: Enqueue on creation?

        return aggregate;
    }

    protected override void OnRegisterEventHandlers(
        ICommandHandlerRegistrator<Guid, Guid, GameState> registrator
    )
    {
        registrator.RegisterCommandHandler<MovePiece, MovingPiece, PieceMoved>();
    }
}