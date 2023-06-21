using DomainFramework;
using CattoChess.Features.Games.Domain.ValueObjects;
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
            Square from,
            Square to
        ) => {
            var result = await request.GetResponse<CommandResult>(
                new MovePiece(gameId, from, to)
            );

            if (!result.Message.Success)
                return Results.BadRequest(result.Message.Message);

            return Results.Ok();
        });
    }
}