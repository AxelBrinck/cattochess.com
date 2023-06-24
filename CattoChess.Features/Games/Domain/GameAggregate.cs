using DomainFramework.Domain.Aggregates;
using CattoChess.Features.Games.Domain.Actions.Create;
using CattoChess.Features.Games.Domain.Actions.MovePiece;
using DomainFramework.Utils;
using DomainFramework.Domain.Events;
using DomainFramework.Domain.Commands;

namespace CattoChess.Features.Games.Domain;

public sealed class GameAggregate : AggregateBase<Guid, Guid, GameAggregateState>
{
    public GameAggregate(GameCreatedDomainEvent creationEvent, bool enqueueCreationEvent = false) : 
        base(creationEvent, enqueueCreationEvent) =>
        State.Board = creationEvent.Board;

    protected override void OnRegisterCommandHandlers(
        TypeMapper<IDomainCommand, IDomainCommandHandler> mapper
    )
    {
        mapper.DefineMap<MovePieceDomainCommand, MovePieceDomainCommandHandler>();
    }

    protected override void OnRegisterEventHandlers(
        TypeMapper<IDomainEvent<Guid>, IDomainEventHandler> mapper
    )
    {
        mapper.DefineMap<PieceMovedDomainEvent, PieceMovedDomainEventHandler>();
    }
}