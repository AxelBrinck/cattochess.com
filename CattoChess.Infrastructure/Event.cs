namespace CattoChess.Infrastructure;

public sealed class Event
{
    public Guid StreamId { get; init; }
    public string Payload { get; init; } = string.Empty;
    public DateTime Timestamp { get; init; } 
}