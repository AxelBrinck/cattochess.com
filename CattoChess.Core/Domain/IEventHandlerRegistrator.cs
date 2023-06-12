namespace CattoChess.Core.Domain;

public interface IEventHandlerRegistrator<TId, TEntity>
    where TId : struct
    where TEntity : class
{
    void RegisterEventHandler<TEventHandler, TEvent>()
        where TEventHandler : IEventHandler<TId, TEntity, TEvent>
        where TEvent : IEvent;
}