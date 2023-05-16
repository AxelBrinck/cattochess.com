namespace CattoChess.Core.Exceptions;

public class EmptyGuidException : DomainException
{
    public EmptyGuidException(string reason) : base(reason)
    {
        
    }
}