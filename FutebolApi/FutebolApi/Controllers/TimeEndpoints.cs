using Microsoft.EntityFrameworkCore;
using FutebolApi.Data;
using FutebolApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace FutebolApi.Controllers;

public static class TimeEndpoints
{
    public static void MapTimeEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Time").WithTags(nameof(Time));

        group.MapGet("/", async (FutebolApiContext db) =>
        {
            return await db.Time.ToListAsync();
        })
        .WithName("GetAllTimes")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Time>, NotFound>> (int id, FutebolApiContext db) =>
        {
            return await db.Time.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Time model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetTimeById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Time time, FutebolApiContext db) =>
        {
            var affected = await db.Time
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, time.Id)
                    .SetProperty(m => m.Nome, time.Nome)
                    .SetProperty(m => m.Pais, time.Pais)
                    .SetProperty(m => m.Fundacao, time.Fundacao)
                    .SetProperty(m => m.Estadio, time.Estadio)
                    .SetProperty(m => m.Capacidade, time.Capacidade)
                    .SetProperty(m => m.Tecnico, time.Tecnico)
                    .SetProperty(m => m.Alcunha, time.Alcunha)
                    .SetProperty(m => m.Liga, time.Liga)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateTime")
        .WithOpenApi();

        group.MapPost("/", async (Time time, FutebolApiContext db) =>
        {
            db.Time.Add(time);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Time/{time.Id}",time);
        })
        .WithName("CreateTime")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, FutebolApiContext db) =>
        {
            var affected = await db.Time
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteTime")
        .WithOpenApi();
    }
}
