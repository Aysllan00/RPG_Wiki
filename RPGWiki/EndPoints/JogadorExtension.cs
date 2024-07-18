using Microsoft.AspNetCore.Mvc;
using RPGWiki.Requests;
using RPGWiki.Responses;
using RPGWiki.Shared.Data.BD;
using RPGWiki_Console;
using System.Runtime.CompilerServices;

namespace RPGWiki.EndPoints
{
    public static class JogadorExtension
    {
        public static void AddEndPointsJogador(this WebApplication app)
        {

            app.MapGet("/Jogador", ([FromServices] DAL<Jogador> dal) => {

                var JogadorList = dal.Read();
                if(JogadorList is null) return Results.NotFound();

                var jogadorResponseList = EntityListToResponseList(JogadorList);
                return Results.Ok(jogadorResponseList);
            });

            app.MapGet("/Jogador/{id}", ([FromServices] DAL<Jogador> dal, int id) => {

                var jogador = dal.ReadByName(h => h.Id == id);
                if (jogador is null) return Results.NotFound();
                return Results.Ok(EntityToResponse(jogador));
            });

            app.MapPost("/Jogador", ([FromServices] DAL<Jogador> dal, [FromBody] JogadorRequest jogadorRequest) => {

                var jogador = new Jogador(jogadorRequest.Nome, jogadorRequest.Moedas);
                dal.Create(jogador);
                return Results.Ok();
            });

            app.MapDelete("/Jogador/{id}", ([FromServices] DAL<Jogador> dal, int id) => {

                var jogador = dal.ReadByName(h => h.Id == id);
                if (jogador is null)
                {
                    return Results.NotFound();
                }
                dal.Delete(jogador);
                return Results.NoContent();

            });

            app.MapPut("/Jogador", ([FromServices] DAL<Jogador> dal, [FromBody] JogadorEditRequest jogadorEditRequest) => {

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