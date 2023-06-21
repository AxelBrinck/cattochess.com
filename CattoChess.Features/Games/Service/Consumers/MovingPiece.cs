using DomainFramework;
using DomainFramework.Domain;
using CattoChess.Features.Games.Domain;
using CattoChess.Features.Games.Service.Commands;
using MassTransit;
using DomainFramework.DataProviders.Time;

namespace CattoChess.Features.Games.Service.Consumers;

public sealed class MovingPiece : IConsumer<MovePiece>
{
    private readonly IAggregateRepository<Guid, Guid, GameState> repository;
    private readonly ITimeProvider timeProvider;

    public MovingPiece(
        IAggregateRepository<Guid, Guid, GameState> repository,
        ITimeProvider timeProvider
    )
    {
        this.repository = repository;
        this.timeProvider = timeProvider;
    }
    
    public async Task Consume(ConsumeContext<MovePiece> context)
    {
        var game = repository.GetById(context.Message.GameId) ??
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