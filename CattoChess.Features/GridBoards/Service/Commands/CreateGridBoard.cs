namespace CattoChess.Features.GridBoards.Service.Commands;

public sealed record CreateGridBoard(Guid Id, int Rows, int Columns);