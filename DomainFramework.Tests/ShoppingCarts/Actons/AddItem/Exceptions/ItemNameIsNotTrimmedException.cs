namespace DomainFramework.Tests.ShoppingCarts.Actons.AddItem.Exceptions;

public sealed class ItemNameIsNotTrimmedException : DomainException
{
    public ItemNameIsNotTrimmedException(string itemName) :
        base($"Item name \"{itemName}\" is not trimmed.")
    {

    }
}