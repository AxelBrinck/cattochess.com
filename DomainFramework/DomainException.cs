namespace DomainFramework;

public abstract class DomainException : Exception
{
    public DomainException(string reason) : base(reason)
    {

    }

    internal DomainException()
    {
        
    }
}