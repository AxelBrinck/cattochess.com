namespace CattoChess.Core.Domain;

public interface IEventHandler<TId, TEntity>
    where TId : struct
    where TEntity : class
{
    object Event { get; }
}

public interface IEventHandler<TId, TEntity, TEvent> : IEventHandler<TId, TEntity>
    where TId : struct
    where TEntity : class
    where TEvent : IEvent
{
    new TEvent Event { get; }

    IEnumerable<IEvent> Handle(
        TEvent @event,
        TEntity entity,
        IReadOnlytAggregateMetadata<TId> metadata
    );
}