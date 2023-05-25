using CattoChess.Core;
using CattoChess.Features.GridBoards.Domain.Events;
using CattoChess.Features.GridBoards.Domain.ValueObjects;

namespace CattoChess.Features.GridBoards.Domain;

public sealed class GridBoard : AggregateRoot<Guid>
{
    public GridBoard(GridBoardCreated @event) : base(@event.Id, @event.Timestamp)
    {
    }

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