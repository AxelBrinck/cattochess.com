using CattoChess.Core;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CattoChess.Infrastructure;

/*
public sealed class MongoDbEventSourcedRepository<TAggregateRoot>
    : IAggregateRepository<Guid, Guid>
        where TAggregateRoot : Aggregate<Guid, Guid>
{
    private readonly IMongoCollection<DomainEvent<Guid>> collection;

    public MongoDbEventSourcedRepository(IOptions<MongoDbSettings> settings) =>
        collection = new MongoClient(settings.Value.ConnectionString)
            .GetDatabase(settings.Value.DatabaseName)
            .GetCollection<DomainEvent<Guid>>("EventStore");
    
    public ValueTask DeleteById(Guid id)
    {
        throw new InvalidOperationException();
    }

    public ValueTask<TAggregateRoot?> GetById(Guid id, int version)
    {
        throw new NotImplementedException();
    }

    public ValueTask<TAggregateRoot?> GetById(Guid id, DateTime time)
    {
        throw new NotImplementedException();
    }

    public ValueTask<TAggregateRoot?> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public ValueTask Insert(TAggregateRoot aggregate)
    {
        foreach(var @event in aggregate.DequeueAllEvents())
            collection.InsertOne(@event);

        return ValueTask.CompletedTask;
    }

    public ValueTask Update(TAggregateRoot entity)
    {
        throw new NotImplementedException();
    }
}
*/