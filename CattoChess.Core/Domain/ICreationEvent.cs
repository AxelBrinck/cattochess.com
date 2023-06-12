namespace CattoChess.Core.Domain;

public interface ICreationEvent<TId> : IEvent<TId> where TId : struct
{
    TId AggregateId { get; }
    string FullyQualifiedAggregateClassName { get; }
}