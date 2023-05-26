using CattoChess.Core;
using CattoChess.Features.Games.Service.Commands;
using MassTransit;

namespace CattoChess.Features.Games.Api.Endpoints;

internal static class MovePieceEndpoint
{
    internal static void MapMovePiece(this WebApplication app)
    {
        app.MapPost("api/move", async (
            IRequestClient<MovePiece> request,
            Guid gameId,
            int fromX,
            int fromY,
            int toX,
            int toY
        ) => {
            var result = await request.GetResponse<CommandResult>(
                new MovePiece(gameId, fromX, fromY, toX, toY)
            );

            if (!result.Message.Success)
                return Results.BadRequest(result.Message.Message);

            return Results.Ok();
        });
    }
}