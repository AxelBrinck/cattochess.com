using DomainFramework.DataProviders.Id;
using DomainFramework.DataProviders.Time;
using DomainFramework.Domain.Aggregates;
using DomainFramework.Domain.Events;

namespace CattoChess.Features.Games.Domain.Actions.MovePiece;

public sealed class MovePieceDomainCommandHandler :
    IDomainCommandHandler<MovePieceDomainCommand, GameAggregateState>
{
    public static IEnumerable<IDomainEvent<Guid>> Handle(
        MovePieceDomainCommand input,
        GameAggregateState state,
        IReadOnlytAggregateMetadata<Guid> metadata,
        IIdProvider<Guid> idProvider,
        ITimeProvider timeProvider
    )
    {
        throw new NotImplementedException();
    }
}