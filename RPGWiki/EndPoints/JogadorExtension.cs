using Microsoft.AspNetCore.Mvc;
using RPGWiki.Requests;
using RPGWiki.Responses;
using RPGWiki.Shared.Data.BD;
using RPGWiki.Shared.Models;
using RPGWiki_Console;
using System.Runtime.CompilerServices;

namespace RPGWiki.EndPoints
{
    public static class JogadorExtension
    {
        public static void AddEndPointsJogador(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("jogadores").RequireAuthorization().WithTags("Jogador");

            groupBuilder.MapGet("", ([FromServices] DAL<Jogador> dal) =>
            {

                var JogadorList = dal.Read();
                if (JogadorList is null) return Results.NotFound();

                var jogadorResponseList = EntityListToResponseList(JogadorList);
                return Results.Ok(jogadorResponseList);
            });

            groupBuilder.MapGet("/{id}", ([FromServices] DAL<Jogador> dal, int id) =>
            {

                var jogador = dal.ReadByName(h => h.Id == id);
                if (jogador is null) return Results.NotFound();
                return Results.Ok(EntityToResponse(jogador));
            });

            groupBuilder.MapPost("", ([FromServices] DAL<Jogador> dal, [FromServices] DAL<Missao> dalMissao, [FromBody] JogadorRequest jogadorRequest) =>
            {

                var jogador = new Jogador(jogadorRequest.Nome, jogadorRequest.Moedas)
                {

                    missoes = jogadorRequest.Missoes is not null ? MissaoRequestConverter(jogadorRequest.Missoes, dalMissao) : new List<Missao>()
                };

                dal.Create(jogador);
                return Results.Ok();
            });

            groupBuilder.MapDelete("/{id}", ([FromServices] DAL<Jogador> dal, int id) =>
            {

                var jogador = dal.ReadByName(h => h.Id == id);
                if (jogador is null)
                {
                    return Results.NotFound();
                }
                dal.Delete(jogador);
                return Results.NoContent();

            });

            groupBuilder.MapPut("", ([FromServices] DAL<Jogador> dal, [FromBody] JogadorEditRequest jogadorEditRequest) =>
            {

                var jogadorToEdit = dal.ReadByName(h => h.Id == jogadorEditRequest.Id);
                if (jogadorToEdit is null)
                {
                    return Results.NotFound();
                }
                jogadorToEdit.Nome = jogadorEditRequest.Nome;
                jogadorToEdit.Moedas = jogadorEditRequest.Moedas;
                dal.Update(jogadorToEdit);
                return Results.Ok();
            });

        }

        private static List<Missao> MissaoRequestConverter(ICollection<MissaoRequest> missoes, DAL<Missao> dalMissao)
        {
            var missaoList = new List<Missao>();
            foreach (var missao in missoes)
            {
                var entity = RequestToEntity(missao);
                var m = dalMissao.ReadByName(a => a.Name.ToUpper().Equals(entity.Name.ToUpper()));
                if (m is not null) {
                    missaoList.Add(m);
                }
                else { missaoList.Add(entity);}
            }
            return missoes.Select(e => RequestToEntity(e)).ToList();
        }

        private static Missao RequestToEntity(MissaoRequest e)
        {
            return new Missao(e.Name, e.Dificuldade);
        }  

        private static ICollection<JogadorResponse> EntityListToResponseList(IEnumerable<Jogador> jogadorList)
        {
            return jogadorList.Select(a => EntityToResponse(a)).ToList();

        }

        private static JogadorResponse EntityToResponse(Jogador a)
        {
            return new JogadorResponse(a.Id, a.Nome, a.Moedas);
        }
    }
}