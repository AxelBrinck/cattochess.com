namespace DomainFramework.Exceptions;

public sealed class MapAlreadyDefinedException : DomainException
{
    public MapAlreadyDefinedException(Type type) : 
        base($"Map for type {type} has already been defined.")
    {
        
    }
}