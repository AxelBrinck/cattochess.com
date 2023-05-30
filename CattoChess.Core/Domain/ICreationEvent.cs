namespace CattoChess.Core.Domain;

public interface ICreationEvent<TId> : IEvent where TId : struct
{
    TId Id { get; }
}