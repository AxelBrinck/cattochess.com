using CattoChess.Core.Domain;
using CattoChess.Features.Games.Domain.Events;

namespace CattoChess.Features.Games.Domain;

public sealed class GameAggregate : Aggregate<Guid, Game>
{
    public GameAggregate(GameCreated creationEvent) : base(creationEvent)
    {
    }

    public static GameAggregate CreateStandardGame(
        IIdProvider<Guid> idProvider,
        ITimeProvider timeProvider
    )
    {
        var @event = new GameCreated()
    }

    protected override void OnRegisterEventHandlers(
        IEventHandlerRegistrator<Guid, Game> registrator
    )
    {
        registrator.RegisterEventHandler<MovePiece, PieceMoved>();
    }
}