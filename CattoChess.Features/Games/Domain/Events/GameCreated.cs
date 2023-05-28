using CattoChess.Core;

namespace CattoChess.Features.Games.Domain.Events;

public sealed record GameCreated : DomainEvent<Guid>
{
    public GameCreated(Game game, ITimeProvider timeProvider) :
        base(game, timeProvider)
    {

    }

    public GameCreated(Guid id, int version, DateTime timestamp) :
        base(id, version, timestamp)
    {
        
    }
}