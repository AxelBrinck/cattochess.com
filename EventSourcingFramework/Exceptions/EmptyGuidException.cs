namespace EventSourcingFramework.Exceptions;

public class EmptyGuidException : DomainException
{
    public EmptyGuidException(string reason) : base(reason)
    {
        
    }
}