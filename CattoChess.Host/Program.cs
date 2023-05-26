using CattoChess.Features.Games.Api;
using CattoChess.Features.Games.Service;
using CattoChess.Infrastructure;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddMassTransit(x => {
        x.AddGameConsumers();
        x.UsingInMemory();
    }).AddMongoDbPersistance(builder.Configuration);

var app = builder.Build();

app.MapGameEndpoints();

app.Run();
