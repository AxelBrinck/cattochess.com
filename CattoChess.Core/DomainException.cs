namespace CattoChess.Core;

public abstract class DomainException : Exception
{
    public DomainException(string reason) : base(reason)
    {

    }

    internal DomainException()
    {
        
    }
}