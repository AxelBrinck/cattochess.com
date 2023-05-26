using CattoChess.Features.Games.Service.Consumers;
using MassTransit;

namespace CattoChess.Features.Games.Service;

public static class Extensions
{
    public static void AddGameConsumers(
        this IBusRegistrationConfigurator busRegistration
    )
    {
        busRegistration.AddConsumer<CreatingGame>();
    }
}