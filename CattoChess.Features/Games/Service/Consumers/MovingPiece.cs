using DomainFramework;
using DomainFramework.Domain;
using CattoChess.Features.Games.Domain;
using CattoChess.Features.Games.Service.Commands;
using MassTransit;
using DomainFramework.DataProviders.Time;
using DomainFramework.Domain.Aggregates;

namespace CattoChess.Features.Games.Service.Consumers;

public sealed class MovingPiece : IConsumer<MovePiece>
{
    private readonly IAggregateRepository<Guid, Guid, GameAggregateState> repository;
    private readonly ITimeProvider timeProvider;

    public MovingPiece(
        IAggregateRepository<Guid, Guid, GameAggregateState> repository,
        ITimeProvider timeProvider
    )
    {
        this.repository = repository;
        this.timeProvider = timeProvider;
    }
    
    public async Task Consume(ConsumeContext<MovePiece> context)
    {
        var game = await repository.GetByIdAsync(context.Message.GameId) ??
            throw new Exception("Game not found.");
        
        /*
        game.MovePiece(
            context.Message.From,
            context.Message.To,
            timeProvider
        );
        */
    }
}