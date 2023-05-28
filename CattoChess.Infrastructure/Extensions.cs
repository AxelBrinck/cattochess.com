using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace CattoChess.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddMongoDbPersistance(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.Configure<MongoDbSettings>(
            configuration.GetSection("MongoDbSettings")
        );

        return services;
    }
}