﻿namespace CattoChess.Core;

public abstract class AggregateRoot<TId> where TId : struct
{
    public TId Id { get; private set; }
    public DateTime CreationTimestamp { get; }
    public DateTime? DeletionTimestamp { get; private set; }

    public DateTime LastModificationTimestamp { get; private set; }

    public int Version { get; private set; } = 1;
    
    private Queue<DomainEvent<TId>> uncommitedEvents { get; } = new();

    public bool TryGettingNextEvent(out DomainEvent<TId>? @event) =>
        uncommitedEvents.TryDequeue(out @event);
    
    public DomainEvent<TId>[] DequeueAllEvents()
    {
        var events = uncommitedEvents.ToArray();
        uncommitedEvents.Clear();
        return events;
    }

    protected AggregateRoot(TId id,  DateTime creationTimestamp)
    {
        Id = id;
        CreationTimestamp = creationTimestamp;
    }

    protected void Enqueue(DomainEvent<TId> @event)
    {
        if (@event == null)
            throw new CannotEnqueueNullEvents();
        
        uncommitedEvents.Enqueue(@event);
    }

    public void AssertNotDeleted()
    {
        if (DeletionTimestamp != null)
            throw new AggregateIsDeleted();
    }

    public abstract void Apply(DomainEvent<Guid> @event);

    public void MarkAsDeleted(DateTime timestamp) =>
        DeletionTimestamp = timestamp;

    protected void ApplyWrapper(DomainEvent<TId> @event, Action action)
    {
        AssertNotDeleted();

        if (LastModificationTimestamp > @event.Timestamp)
            throw new EventTimestampIsNotNewer();

        LastModificationTimestamp = @event.Timestamp;
        Version++;
        action.Invoke();
    }

    public sealed class EventTimestampIsNotNewer : DomainException
    {
        
    }

    public sealed class CannotEnqueueNullEvents : DomainException
    {

    }

    public sealed class AggregateIsDeleted : DomainException
    {
        
    }
}