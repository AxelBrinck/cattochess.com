using CattoChess.Core;

namespace CattoChess.Features.GridBoards.Domain.Events;

public sealed record GridBoardCreated : DomainEvent
{
    public Guid Id { get; }
    public int Rows { get; }
    public int Columns { get; }

    public GridBoardCreated(
        Guid id,
        int rows,
        int columns,
        ITimeProvider timeProvider
    ) : base(timeProvider)
    {
        Id = id;
        Rows = rows;
        Columns = columns;
    }

    public GridBoardCreated(
        Guid id,
        int rows,
        int columns,
        DateTime timestamp
    ) : base(timestamp)
    {
        Id = id;
        Rows = rows;
        Columns = columns;
    }
}