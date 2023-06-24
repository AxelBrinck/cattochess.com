using CattoChess.Features.Games.Domain.Classes;
using DomainFramework.Domain.Events;

namespace CattoChess.Features.Games.Domain.Actions.Create;

public sealed record GameCreatedDomainEvent(
    Guid EventId,
    Guid AggregateId,
    string AggregateStreamName,
    DateTime Timestamp,
    ChessBoard Board
) : IDomainCreationEvent<Guid, Guid>;