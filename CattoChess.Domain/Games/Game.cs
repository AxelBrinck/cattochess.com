using CattoChess.Core;
using CattoChess.Domain.Accounts.ValueObjects;
using CattoChess.Domain.Games.Events;
using CattoChess.Domain.Games.ValueObjects;

namespace CattoChess.Domain.Games;

public sealed class Game : AggregateRoot<GameId>
{
    public AccountId AccountCreatorId { get; }

    private Game(GameCreated @event) : base(@event.Id, @event.Timestamp) =>
        AccountCreatorId = @event.AccountCreatorId;
    
    public static Game Create(
        Guid id,
        Guid accountCreatorId,
        ITimeProvider timeProvider)
    {
        var @event = new GameCreated(id, accountCreatorId, timeProvider);
        var game = new Game(@event);
        game.Enqueue(@event);
        return game;
    }

}