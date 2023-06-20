namespace CattoChess.Core.Domain.Commands;

public interface ICommandHandler<TCommand> where TCommand : ICommand
{
    public IEnumerable<
}