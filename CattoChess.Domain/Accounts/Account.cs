using CattoChess.Core;
using CattoChess.Domain.Accounts.Events;
using CattoChess.Domain.Accounts.ValueObjects;

namespace CattoChess.Domain.Accounts;

public sealed class Account : AggregateRoot<AccountId>
{
    public Username? Username { get; private set; }
    

    private Account(AccountCreated @event) : 
        base(@event.Id, @event.Timestamp)
    {

    }

    public static Account Create(
        AccountId id,
        Email email,
        ITimeProvider timeProvider
    )
    {
        var @event = new AccountCreated(id, email, timeProvider);
        var account = new Account(@event);
        account.Enqueue(@event);
        return account;
    }

    public void UpdateUserName(Username newUserName, ITimeProvider timeProvider)
    {
        var @event = new UsernameUpdated(newUserName, timeProvider);

        Enqueue(@event);
        Apply(@event);
    }
    public void Apply(UsernameUpdated @event) =>
        ApplyWrapper(@event.Timestamp, () => Username = @event.NewUserName);
}