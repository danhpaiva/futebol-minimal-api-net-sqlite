using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FutebolApi.Data;
using FutebolApi.Controllers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FutebolApiContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("FutebolApiContext") ?? throw new InvalidOperationException("Connection string 'FutebolApiContext' not found.")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapJogadorEndpoints();

app.MapTimeEndpoints();

app.Run();
