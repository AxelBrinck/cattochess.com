using CattoChess.Core;
using CattoChess.Features.Games.Domain;
using CattoChess.Features.Games.Service.Commands;
using MassTransit;

namespace CattoChess.Features.Games.Service.Consumers;

public sealed class MovingPiece : IConsumer<MovePiece>
{
    private readonly IRepository<Game, Guid> repository;
    private readonly ITimeProvider timeProvider;

    public MovingPiece(
        IRepository<Game, Guid> repository,
        ITimeProvider timeProvider
    )
    {
        this.repository = repository;
        this.timeProvider = timeProvider;
    }
    
    public async Task Consume(ConsumeContext<MovePiece> context)
    {
        var game = await repository.GetById(context.Message.GameId) ??
            throw new Exception("Game not found.");
        
        game.MovePiece(
            context.Message.From,
            context.Message.To,
            timeProvider
        );
    }
}