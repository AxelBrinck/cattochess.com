using CattoChess.Core;
using CattoChess.Core.Domain;
using CattoChess.Features.Games.Domain;
using CattoChess.Features.Games.Service.Commands;
using MassTransit;

namespace CattoChess.Features.Games.Service.Consumers;

public sealed class CreatingGame : IConsumer<CreateGame>
{
    private readonly IRepository<Guid, Game> repository;
    private readonly ITimeProvider timeProvider;

    public CreatingGame(
        IRepository<Guid, Game> repository,
        ITimeProvider timeProvider
    )
    {
        this.repository = repository;
        this.timeProvider = timeProvider;
    }

    public async Task Consume(ConsumeContext<CreateGame> context)
    {
        await repository.Insert(
            Game
        );
    }
}