namespace DomainFramework.Exceptions;

public class EmptyGuidException : DomainException
{
    public EmptyGuidException(string reason) : base(reason)
    {
        
    }
}