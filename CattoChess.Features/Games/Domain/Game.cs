using CattoChess.Core;
using CattoChess.Features.Games.Domain.Events;
using CattoChess.Features.Games.Domain.ValueObjects;

namespace CattoChess.Features.Games.Domain;

public sealed class Game : AggregateRoot<GameId>
{
    public Game(GameCreated @event) : base(@event.Id, @event.Timestamp)
    {

    }

    public static Game Create(GameId gameId, ITimeProvider timeProvider)
    {
        var @event = new GameCreated(gameId, timeProvider);
        var game = new Game(@event);
        game.Enqueue(@event);
        return game;
    }

    public override void Apply(DomainEvent @event)
    {
        throw new NotImplementedException();
    }
}