using CattoChess.Core;
using CattoChess.Features.Games.Domain.Classes;
using CattoChess.Features.Games.Domain.Events;
using CattoChess.Features.Games.Domain.ValueObjects;

namespace CattoChess.Features.Games.Domain;

public sealed class Game : AggregateRoot<Guid>
{
    private readonly List<ChessPiece> Pieces = new();
    public Player CurrentTurn { get; } = Player.White;
    
    public Game(GameCreated @event) : base(@event.Id, @event.Timestamp)
    {
    }

    public static Game Create(GameId GridBoardId, ITimeProvider timeProvider)
    {
        var @event = new GameCreated(GridBoardId, timeProvider);
        var GridBoard = new Game(@event);
        GridBoard.Enqueue(@event);
        return GridBoard;
    }

    public override void Apply(DomainEvent @event)
    {
        throw new NotImplementedException();
    }

    public void Move(int fromX, int fromY, int toX, int toY)
    {
        throw new NotImplementedException();
    }
}