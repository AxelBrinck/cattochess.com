using CattoChess.Features.GridBoards.Service;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(x => {
    x.AddGridBoardConsumers();
    x.UsingInMemory();
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
