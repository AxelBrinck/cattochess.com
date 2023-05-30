namespace CattoChess.Core.Domain;

public interface IEvent
{
    DateTime Timestamp { get; }
    string Class { get; }
}