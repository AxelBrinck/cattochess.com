namespace DomainFramework.Tests.ShoppingCarts;

public sealed class ShoppingCartAggregateState : ICloneable
{
    public List<string> Items { get; } = new();

    public object Clone()
    {
        var clone = new ShoppingCartAggregateState();
        
        foreach (var item in Items)
            clone.Items.Add(item);

        return clone;
    }
}