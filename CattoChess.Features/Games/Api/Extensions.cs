using CattoChess.Features.Games.Api.Endpoints;

namespace CattoChess.Features.Games.Api;

public static class Extensions
{
    public static void MapGameEndpoints(this WebApplication app)
    {
        app.MapMovePiece();
    }
}
