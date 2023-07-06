namespace DomainFramework.Tests.ShoppingCarts.Actons.AddItem.Exceptions;

public sealed class ItemNameIsNotLowerCaseException : DomainException
{
    public ItemNameIsNotLowerCaseException(string itemName) :
        base($"Item name \"{itemName}\" is not lower case.")
    {
        
    }
}