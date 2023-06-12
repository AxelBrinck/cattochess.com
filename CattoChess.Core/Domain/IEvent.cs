namespace CattoChess.Core.Domain;

public interface IEvent
{

}

public interface IEvent<TId> : IEvent where TId : struct
{
    TId Id { get; }
    DateTime Timestamp { get; }
}