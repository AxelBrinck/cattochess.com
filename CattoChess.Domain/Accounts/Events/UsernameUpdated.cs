using CattoChess.Core;

namespace CattoChess.Domain.Accounts.Events;

public sealed record UsernameUpdated : DomainEvent
{
    public string NewUserName { get; }

    public UsernameUpdated(
        string newUserName,
        ITimeProvider timeProvider
    ) : base(timeProvider) =>
        NewUserName = newUserName;
    
    public UsernameUpdated(
        string newUserName,
        DateTime timestamp
    ) : base(timestamp) =>
        NewUserName = newUserName;
}