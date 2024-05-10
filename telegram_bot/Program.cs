using bot_entities;
using telegram_services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddUserEntities();
builder.Services.AddTelegramServices();

var app = builder.Build();
app.Run();