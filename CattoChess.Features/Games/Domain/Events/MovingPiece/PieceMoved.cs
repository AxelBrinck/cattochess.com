using CattoChess.Core.Domain;

namespace CattoChess.Features.Games.Domain.Events.MovingPiece;

public sealed record PieceMoved : Event<Guid>
{
    public PieceMoved(IIdProvider<Guid> idProvider, ITimeProvider timeProvider) : base(idProvider, timeProvider)
    {

    }

    public PieceMoved(Guid id, DateTime timestamp) : base(id, timestamp)
    {
        
    }
}