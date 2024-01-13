using Template.Domain.Entities;
using Template.Persistence.Context;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Template.IntegrationTests.MapperEndpoint
{
    public static class OcorrenciaEndpoints
    {
        public static RouteGroupBuilder MapOcorrenciaEndpoints(this RouteGroupBuilder group)
        {
            group.MapGet("api/Ocorrencia/getall", GetAll);
            group.MapGet("/api/ocorrencias/getbyid/{id}", GetById);
            group.MapPost("/api/ocorrencias/create", AddOcorrencia);

            return group;
        }

        public static Created<Ocorrencia> AddOcorrencia(Ocorrencia ocorrencia, AppDbContext context)
        {
            context.Ocorrencia.Add(ocorrencia);
            context.SaveChanges();

            return TypedResults.Created($"/api/ocorrencias/getbyid/{ocorrencia.Id}", ocorrencia);
        }
        public static async Task<Results<Ok<Ocorrencia>, NotFound>> GetById(int id, AppDbContext context)
        {
            var ocorrencia = await context.Ocorrencia.FindAsync(id);

            if (ocorrencia != null)
            {
                return TypedResults.Ok(ocorrencia);
            }

            return TypedResults.NotFound();
        }

        public static async Task<Ok<Ocorrencia[]>> GetAll(AppDbContext context)
        {
            var ocorrencias = await context.Ocorrencia.ToArrayAsync();

            return TypedResults.Ok(ocorrencias);
        }
    }
}
