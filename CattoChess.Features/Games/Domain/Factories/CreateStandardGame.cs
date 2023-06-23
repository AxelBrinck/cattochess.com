using CattoChess.Features.Games.Domain.Actions.CreateGame;
using CattoChess.Features.Games.Domain.Classes;
using CattoChess.Features.Games.Domain.ValueObjects;
using DomainFramework.DataProviders.Id;
using DomainFramework.DataProviders.Time;

namespace CattoChess.Features.Games.Domain.Factories;

public static class StandardGameFactory
{
    public static GameAggregate Create(
        GameId gameId,
        IIdProvider<Guid> idProvider,
        ITimeProvider timeProvider
    ) =>
        new GameAggregate(
            new GameCreatedDomainEvent(
                gameId,
                ChessBoard.CreateStandardBoard(),
                typeof(GameAggregate).FullName ?? throw new Exception(),
                idProvider,
                timeProvider
            ), 
            enqueueCreationEvent: true
        );
}