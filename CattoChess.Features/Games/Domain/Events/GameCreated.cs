using CattoChess.Core.Domain.DataProviders;
using CattoChess.Core.Domain.Events;

namespace CattoChess.Features.Games.Domain.Events;

public sealed record GameCreated : CreationEvent<Guid, Guid>
{
    public GameCreated(
        Guid aggregateId,
        string fullyQualifiedEventClassName,
        IIdProvider<Guid> idProvider,
        ITimeProvider timeProvider
    ) : base(
        aggregateId,
        fullyQualifiedEventClassName,
        idProvider,
        timeProvider
    )
    {

    }

    public GameCreated(
        Guid aggregateId,
        string fullyQualifiedEventClassName,
        Guid id,
        DateTime timestamp
    ) : base(
        aggregateId,
        fullyQualifiedEventClassName,
        id,
        timestamp
    )
    {

    }
}