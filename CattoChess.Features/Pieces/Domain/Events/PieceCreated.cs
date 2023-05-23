using CattoChess.Core;

namespace CattoChess.Features.Pieces.Domain.Events;

public sealed record PieceCreated : DomainEvent
{
    public Guid Id { get; }
    public Guid GridBoardId { get; }

    public PieceCreated(
        Guid id,
        Guid gridBoardId,
        ITimeProvider timeProvider
    ) : base(timeProvider)
    {
        Id = id;
        GridBoardId = gridBoardId;
    }

    public PieceCreated(
        Guid id,
        Guid gridBoardId,
        DateTime timestamp
    ) : base(timestamp)
    {
        Id = id;
        GridBoardId = gridBoardId;
    }
}