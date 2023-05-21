using CattoChess.Core;

namespace CattoChess.Features.Pieces.Domain.Events;

public sealed record PieceCreated : DomainEvent
{
    public Guid Id { get; }
    public Guid BoardId { get; }

    public PieceCreated(
        Guid id,
        Guid boardId,
        ITimeProvider timeProvider
    ) : base(timeProvider)
    {
        Id = id;
        BoardId = boardId;
    }

    public PieceCreated(
        Guid id,
        Guid boardId,
        DateTime timestamp
    ) : base(timestamp)
    {
        Id = id;
        BoardId = boardId;
    }
}