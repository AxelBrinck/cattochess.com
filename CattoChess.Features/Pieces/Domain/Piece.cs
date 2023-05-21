using CattoChess.Core;
using CattoChess.Features.Pieces.Domain.Events;
using CattoChess.Features.Pieces.Domain.ValueObjects;

namespace CattoChess.Features.Pieces.Domain;

public sealed class Piece : AggregateRoot<PieceId>
{
    public Piece(PieceCreated @event) : base(@event.Id, @event.Timestamp)
    {
    }

    public static Piece Create(
        Guid id,
        Guid boardId,
        ITimeProvider timeProvider)
    {
        var @event = new PieceCreated(id, boardId, timeProvider);
        var piece = new Piece(@event);
        piece.Enqueue(@event);
        return piece;
    }

    public override void Apply(DomainEvent @event)
    {
        throw new NotImplementedException();
    }
}
