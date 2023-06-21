using DomainFramework.Domain.Events;
using CattoChess.Features.Games.Domain.Classes;
using DomainFramework.DataProviders.Id;
using DomainFramework.DataProviders.Time;

namespace CattoChess.Features.Games.Domain.Events;

public sealed record GameCreated : CreationEventBase<Guid, Guid>
{
    public ChessBoard Board { get; }
    
    public GameCreated(
        Guid aggregateId,
        ChessBoard board,
        string fullyQualifiedEventClassName,
        IIdProvider<Guid> idProvider,
        ITimeProvider timeProvider
    ) : base(
        aggregateId,
        fullyQualifiedEventClassName,
        idProvider,
        timeProvider
    ) =>
        Board = board;

    public GameCreated(
        Guid aggregateId,
        ChessBoard board,
        string fullyQualifiedEventClassName,
        Guid id,
        DateTime timestamp
    ) : base(
        aggregateId,
        fullyQualifiedEventClassName,
        id,
        timestamp
    ) =>
        Board = board;
}