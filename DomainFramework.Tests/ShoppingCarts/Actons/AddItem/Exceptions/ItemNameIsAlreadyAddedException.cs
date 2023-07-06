namespace DomainFramework.Tests.ShoppingCarts.Actons.AddItem.Exceptions;

public sealed class ItemNameIsAlreadyAddedException : DomainException
{
    public ItemNameIsAlreadyAddedException(string itemName) : 
        base($"Item name \"{itemName}\" is already added.")
    {

    }
}