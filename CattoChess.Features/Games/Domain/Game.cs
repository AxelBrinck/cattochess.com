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
    public void Apply(PieceMoved @event) => ApplyWrapper(
        @event,
        () => chessBoard.MovePiece(
            @event.From,
            @event.To
        )
    );
}