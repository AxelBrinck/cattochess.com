using CattoChess.Features.Games.Domain.ValueObjects;
using DomainFramework.Domain.Commands;

namespace CattoChess.Features.Games.Domain.Actions.MovePiece;

public sealed record MovePieceDomainCommand(
    Square From,
    Square To
) : IDomainCommand;