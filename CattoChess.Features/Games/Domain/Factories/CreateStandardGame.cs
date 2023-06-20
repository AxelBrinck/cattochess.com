using EventSourcingFramework.Domain.DataProviders;
using CattoChess.Features.Games.Domain.Classes;
using CattoChess.Features.Games.Domain.Events;
using CattoChess.Features.Games.Domain.ValueObjects;

namespace CattoChess.Features.Games.Domain.Factories;

public static class StandardGameFactory
{
    public static GameAggregate Create(
        GameId gameId,
        IIdProvider<Guid> idProvider,
        ITimeProvider timeProvider
    ) =>
        new GameAggregate(
            new GameCreated(
                gameId,
                ChessBoard.CreateStandardBoard(),
                typeof(GameAggregate).FullName ?? throw new Exception(),
                idProvider,
                timeProvider
            ), 
            enqueueCreationEvent: true
        );
}