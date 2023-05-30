using CattoChess.Core;
using CattoChess.Features.Games.Domain.Classes;
using CattoChess.Features.Games.Domain.Events;
using CattoChess.Features.Games.Domain.ValueObjects;

namespace CattoChess.Features.Games.Domain;

public sealed class Game : AggregateRoot<Guid>
{
    private readonly ChessBoard chessBoard = ChessBoard.CreateStandardBoard();
    public Player CurrentTurn { get; } = Player.White;
    
    public Game(GameCreated @event) : 
        base(@event.AggregateRootId, @event.Timestamp)
    {

    }
    public static Game Create(GameId GridBoardId, ITimeProvider timeProvider)
    {
        var @event = new GameCreated(
            GridBoardId,
            version: 0,
            timeProvider.GetCurrentTime());

        var game = new Game(@event);
        game.Enqueue(@event);
        return game;
    }

    public override void Apply(DomainEvent<Guid> @event)
    {
        switch (@event)
        {
        case PieceMoved e:
            ApplyMovePiece(e);
            break;
        }
    }

    public void MovePiece(
        Square from,
        Square to,
        ITimeProvider timeProvider
    )
    {
        chessBoard.AssertPieceAbilityToMove(from, to);
        
        var @event = new PieceMoved(game: this, timeProvider, from, to);
        Enqueue(@event);
        Apply(@event);
    }
    private void ApplyMovePiece(PieceMoved @event) => ApplyWrapper(
        @event,
        () => chessBoard.MovePiece(
            @event.From,
            @event.To
        )
    );
}