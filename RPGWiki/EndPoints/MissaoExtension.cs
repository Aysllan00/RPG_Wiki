using Microsoft.AspNetCore.Mvc;
using RPGWiki.Requests;
using RPGWiki.Responses;
using RPGWiki.Shared.Data.BD;
using RPGWiki.Shared.Models;
using RPGWiki_Console;

namespace RPGWiki.EndPoints
{
    public static class MissaoExtension
    {
        public static void AddEndPointsMissao(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("missoes").RequireAuthorization().WithTags("Missão");

            groupBuilder.MapGet("", ([FromServices] DAL<Missao> dal) =>
            {

                var MissaoList = dal.Read();
                if (MissaoList is null) return Results.NotFound();

                var missaoResponseList = EntityListToResponseList(MissaoList);
                return Results.Ok(missaoResponseList);
            });

            groupBuilder.MapPost("", ([FromServices] DAL<Missao> dal, [FromBody] MissaoRequest missaoResponse) =>
            {

                dal.Create(RequestToEntity(missaoResponse));
                return Results.Ok();
            });

            groupBuilder.MapDelete("/{id}", ([FromServices] DAL<Missao> dal, int id) =>
            {

                var missao = dal.ReadByName(h => h.Id == id);
                if (missao is null)
                {
                    return Results.NotFound();
                }
                dal.Delete(missao);
                return Results.NoContent();
            });

            groupBuilder.MapGet("/{id}/jogadores", ([FromServices] DAL<Missao> dal, [FromServices] DAL<Jogador> dalJogador, int id) =>
            {
                var missao = dal.ReadByName(m => m.Id == id);
                if (missao is null) return Results.NotFound();

                var jogadores = dalJogador.Read().Where(j => j.missoes.Any(m => m.Id == id)).ToList();
                var jogadorResponseList = jogadores.Select(j => new JogadorResponse(j.Id, j.Nome, j.Moedas)).ToList();

                return Results.Ok(jogadorResponseList);
            });
        }

        private static Missao RequestToEntity(MissaoRequest e)
        {
            return new Missao(e.Name, e.Dificuldade);
        }

        private static ICollection<MissaoResponse> EntityListToResponseList(IEnumerable<Missao> missoaoList)
        {
            return missoaoList.Select(e => EntityToResponse(e)).ToList();
        }

        private static MissaoResponse EntityToResponse(Missao e)
        {
            return new MissaoResponse(e.Id, e.Name, e.Dificuldade);
        }
    }
}
