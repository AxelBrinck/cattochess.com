using CattoChess.Core;

namespace CattoChess.Features.Board.Domain.Events;

public sealed record BoardCreated : DomainEvent
{
    public Guid Id { get; }
    public int Rows { get; }
    public int Columns { get; }

    public BoardCreated(
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

    public BoardCreated(
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