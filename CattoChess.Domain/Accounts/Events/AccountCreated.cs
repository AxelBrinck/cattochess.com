using CattoChess.Core;

namespace CattoChess.Domain.Accounts.Events;

public sealed record AccountCreated : DomainEvent
{
    public Guid Id { get; }
    public string Email { get; }

    public AccountCreated(
        Guid accountId,
        string email,
        ITimeProvider timeProvider
    ) : base(timeProvider)
    {
        Id = accountId;
        Email = email;
    }

    public AccountCreated(
        Guid accountId,
        string email,
        DateTime timestamp) : 
        base(timestamp)
    {
        Id = accountId;
        Email = email;
    }
}