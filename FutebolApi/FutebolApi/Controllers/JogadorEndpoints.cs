using Microsoft.EntityFrameworkCore;
using FutebolApi.Data;
using FutebolApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace FutebolApi.Controllers;

public static class JogadorEndpoints
{
    public static void MapJogadorEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Jogador").WithTags(nameof(Jogador));

        group.MapGet("/", async (FutebolApiContext db) =>
        {
            return await db.Jogador.ToListAsync();
        })
        .WithName("GetAllJogadors")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Jogador>, NotFound>> (int id, FutebolApiContext db) =>
        {
            return await db.Jogador.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Jogador model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetJogadorById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Jogador jogador, FutebolApiContext db) =>
        {
            var affected = await db.Jogador
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, jogador.Id)
                    .SetProperty(m => m.Nome, jogador.Nome)
                    .SetProperty(m => m.Idade, jogador.Idade)
                    .SetProperty(m => m.Nacionalidade, jogador.Nacionalidade)
                    .SetProperty(m => m.UltimoClube, jogador.UltimoClube)
                    .SetProperty(m => m.Posicao, jogador.Posicao)
                    .SetProperty(m => m.Qtde_Gols, jogador.Qtde_Gols)
                    .SetProperty(m => m.SalarioMensal, jogador.SalarioMensal)
                    .SetProperty(m => m.Altura, jogador.Altura)
                    .SetProperty(m => m.Peso, jogador.Peso)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateJogador")
        .WithOpenApi();

        group.MapPost("/", async (Jogador jogador, FutebolApiContext db) =>
        {
            db.Jogador.Add(jogador);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Jogador/{jogador.Id}",jogador);
        })
        .WithName("CreateJogador")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, FutebolApiContext db) =>
        {
            var affected = await db.Jogador
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteJogador")
        .WithOpenApi();
    }
}
