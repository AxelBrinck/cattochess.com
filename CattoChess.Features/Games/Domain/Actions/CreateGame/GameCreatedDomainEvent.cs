using DomainFramework.Domain.Events;
using CattoChess.Features.Games.Domain.Classes;
using DomainFramework.DataProviders.Id;
using DomainFramework.DataProviders.Time;

namespace CattoChess.Features.Games.Domain.Actions.CreateGame;

public sealed record GameCreatedDomainEvent : DomainCreationEventBase<Guid, Guid>
{
    public ChessBoard Board { get; }
    
    public GameCreatedDomainEvent(
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

    public GameCreatedDomainEvent(
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