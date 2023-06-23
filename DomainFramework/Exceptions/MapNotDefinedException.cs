namespace DomainFramework.Exceptions;

public sealed class MapNotDefinedException : DomainException
{
    public MapNotDefinedException(Type type) : base($"Map not defined for type {type}.")
    {
        
    }
}