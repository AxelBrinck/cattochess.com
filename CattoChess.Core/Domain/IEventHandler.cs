namespace CattoChess.Core.Domain;

public interface IEventHandler<TId, TEntity, TEvent>
    where TId : struct
    where TEntity : class
    where TEvent : IEvent
{
    IEnumerable<IEvent> AssertValid(TEvent @event, TEntity entity, IReadOnlytAggregateMetadata<TId> aggregateMetadata);
    IEnumerable<IEvent> Apply(TEvent @event, TEntity entity, IReadOnlytAggregateMetadata<TId> aggregateMetadata);
}