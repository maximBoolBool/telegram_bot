using bot_entities;
using telegram_bot;
using telegram_services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEnviromentVariables(builder.Configuration);
builder.Services.AddUserEntities(builder.Configuration);
builder.Services.AddTelegramServices();

var app = builder.Build();
await app.RunAsync();