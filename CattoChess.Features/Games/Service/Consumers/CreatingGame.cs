using CattoChess.Features.Games.Domain;
using CattoChess.Features.Games.Service.Commands;
using MassTransit;
using DomainFramework.DataProviders.Time;
using DomainFramework.Domain.Aggregates;

namespace CattoChess.Features.Games.Service.Consumers;

public sealed class CreatingGame : IConsumer<CreateGame>
{
    private readonly IAggregateRepository<Guid, Guid, GameAggregateState> repository;
    private readonly ITimeProvider timeProvider;

    public CreatingGame(
        IAggregateRepository<Guid, Guid, GameAggregateState> repository,
        ITimeProvider timeProvider
    )
    {
        this.repository = repository;
        this.timeProvider = timeProvider;
    }

    public async Task Consume(ConsumeContext<CreateGame> context)
    {
        // TODO: Finish this: await repository.Insert();
    }
}