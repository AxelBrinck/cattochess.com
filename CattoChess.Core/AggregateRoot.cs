namespace CattoChess.Core;

public abstract class Aggregate<TId> where TId : notnull
{
    public TId Id { get; private set; }
    public DateTime CreationTimestamp { get; }

    protected void ChangedId(TId newId) =>
        Id = newId;

    protected Aggregate(
        TId id,
        DateTime creationTimestamp
    )
    {
        Id = id;
        CreationTimestamp = creationTimestamp;
    }
}

public abstract class AggregateRoot<TId> : Aggregate<TId> where TId : notnull
{
    public DateTime? DeletionTimestamp { get; private set; }

    public DateTime LastModificationTimestamp { get; private set; }

    public int Version { get; private set; } = 1;
    
    private Queue<object> uncommitedEvents { get; } = new();

    public bool TryGettingNextEvent(out object? @event) =>
        uncommitedEvents.TryDequeue(out @event);
    
    public object[] DequeueAllEvents()
    {
        var events = uncommitedEvents.ToArray();
        uncommitedEvents.Clear();
        return events;
    }

    protected AggregateRoot(
        TId id,
        DateTime creationTimestamp
    ) : base(id, creationTimestamp) =>
        LastModificationTimestamp = creationTimestamp;

    protected void Enqueue(object @event)
    {
        if (@event == null)
            throw new CannotEnqueueNullEvents();
        
        uncommitedEvents.Enqueue(@event);
    }

    public void EnsureNotDeleted()
    {
        if (DeletionTimestamp != null)
            throw new AggregateIsDeleted();
    }

    public void MarkAsDeleted(DateTime timestamp) =>
        DeletionTimestamp = timestamp;

    protected void ApplyWrapper(DateTime timestamp, Action action)
    {
        if (LastModificationTimestamp > timestamp)
            throw new EventNotNewerToBeApplied();

        LastModificationTimestamp = timestamp;
        Version++;
        action.Invoke();
    }

    public sealed class EventNotNewerToBeApplied : DomainException
    {
        
    }

    public sealed class CannotEnqueueNullEvents : DomainException
    {

    }

    public sealed class AggregateIsDeleted : DomainException
    {
        
    }
}