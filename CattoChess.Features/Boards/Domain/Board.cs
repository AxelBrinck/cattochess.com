using CattoChess.Core;
using CattoChess.Features.Board.Domain.Events;
using CattoChess.Features.Board.Domain.ValueObjects;

namespace CattoChess.Features.Board.Domain;

public sealed class Board : AggregateRoot<BoardId>
{
    private Guid[,] grid { get; }

    public Board(BoardCreated @event) : base(@event.Id, @event.Timestamp) =>
        grid = new Guid[@event.Columns, @event.Rows];

    public static Board Create(
        BoardId boardId,
        int rows,
        int columns,
        ITimeProvider timeProvider
    )
    {
        var @event = new BoardCreated(boardId, rows, columns, timeProvider);
        var Board = new Board(@event);
        Board.Enqueue(@event);
        return Board;
    }

    public override void Apply(DomainEvent @event)
    {
        throw new NotImplementedException();
    }
}