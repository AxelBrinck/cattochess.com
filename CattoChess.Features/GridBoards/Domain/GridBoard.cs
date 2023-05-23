using CattoChess.Core;
using CattoChess.Features.GridBoard.Domain.Events;
using CattoChess.Features.GridBoard.Domain.ValueObjects;

namespace CattoChess.Features.GridBoard.Domain;

public sealed class GridBoard : AggregateRoot<GridBoardId>
{
    private Guid[,] grid { get; }

    public GridBoard(GridBoardCreated @event) : base(@event.Id, @event.Timestamp) =>
        grid = new Guid[@event.Columns, @event.Rows];

    public static GridBoard Create(
        GridBoardId GridBoardId,
        int rows,
        int columns,
        ITimeProvider timeProvider
    )
    {
        var @event = new GridBoardCreated(GridBoardId, rows, columns, timeProvider);
        var GridBoard = new GridBoard(@event);
        GridBoard.Enqueue(@event);
        return GridBoard;
    }

    public override void Apply(DomainEvent @event)
    {
        throw new NotImplementedException();
    }
}