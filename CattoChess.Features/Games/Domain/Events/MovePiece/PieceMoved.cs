using CattoChess.Core.Domain.DataProviders;
using CattoChess.Core.Domain.Events;

namespace CattoChess.Features.Games.Domain.Events.MovePiece;

public sealed record PieceMoved : Event<Guid>
{
    public PieceMoved(IIdProvider<Guid> idProvider, ITimeProvider timeProvider) : base(idProvider, timeProvider)
    {

    }

    public PieceMoved(Guid id, DateTime timestamp) : base(id, timestamp)
    {
        
    }
}