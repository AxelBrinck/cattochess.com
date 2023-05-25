using CattoChess.Features.GridBoards.Service.Consumers;
using MassTransit;

namespace CattoChess.Features.GridBoards.Service;

public static class Extensions
{
    public static void AddGridBoardConsumers(
        this IBusRegistrationConfigurator busRegistration
    )
    {
        busRegistration.AddConsumer<CreatingGridBoard>();
    }
}