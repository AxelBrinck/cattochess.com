using CattoChess.Core;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CattoChess.Infrastructure;

public sealed class MongoDbEventSourcedRepository<TAggregateRoot>
    : IEventSourcedRepository<TAggregateRoot, Guid>
        where TAggregateRoot : AggregateRoot<Guid>
{
    private readonly IMongoCollection<Event> collection;

    public MongoDbEventSourcedRepository(IOptions<MongoDbSettings> settings)
    {
        var database = new MongoClient(settings.Value.ConnectionString)
            .GetDatabase(settings.Value.DatabaseName);
        
        collection = database.GetCollection<Event>("EventStore");
    }
    
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
            collection.InsertOne(new Event {
                StreamId = aggregate.Id,
                Payload = System.Text.Json.JsonSerializer.Serialize(@event),
                Timestamp = ((DomainEvent) @event).Timestamp
            });

        return ValueTask.CompletedTask;
    }

    public ValueTask Update(TAggregateRoot entity)
    {
        throw new NotImplementedException();
    }
}
