using CattoChess.Core;
using CattoChess.Features.GridBoards.Domain;
using CattoChess.Features.GridBoards.Service.Commands;
using MassTransit;

namespace CattoChess.Features.GridBoards.Service.Consumers;

public sealed class CreatingGridBoard : IConsumer<CreateGridBoard>
{
    private readonly IRepository<GridBoard, Guid> repository;
    private readonly ITimeProvider timeProvider;

    public CreatingGridBoard(
        IRepository<GridBoard, Guid> repository,
        ITimeProvider timeProvider
    )
    {
        this.repository = repository;
        this.timeProvider = timeProvider;
    }

    public async Task Consume(ConsumeContext<CreateGridBoard> context)
    {
        await repository.Insert(
            GridBoard.Create(
                context.Message.Id,
                context.Message.Rows,
                context.Message.Columns,
                timeProvider
            )
        );
    }
}