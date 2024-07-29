﻿using Microsoft.AspNetCore.Mvc;
using RPGWiki.Requests;
using RPGWiki.Responses;
using RPGWiki.Shared.Data.BD;
using RPGWiki_Console;

namespace RPGWiki.EndPoints
{
    public static class PersonagemExtension
    {

        public static void AddPointsPersonagem(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("personagens").RequireAuthorization().WithTags("Personagem");

            groupBuilder.MapGet("", ([FromServices] DAL<Personagem> dal) =>
            {

                var personagemList = dal.Read();
                if (personagemList is null) return Results.NotFound();

                var personagemResponseList = EntityListToResponseList(personagemList);
                return Results.Ok(personagemResponseList);
            });

            groupBuilder.MapGet("/{id}", ([FromServices] DAL<Personagem> dal, int id) =>
            {

                var personagem = dal.ReadByName(h => h.Id == id);
                if (personagem is null) return Results.NotFound();
                return Results.Ok(EntityToResponse(personagem));
            });

            groupBuilder.MapPost("", ([FromServices] DAL<Personagem> dal, [FromBody] PersonagemRequest personagemRequest) =>
            {

                var personagem = new Personagem(personagemRequest.name);
                dal.Create(personagem);
                return Results.Ok();
            });

            groupBuilder.MapDelete("/{id}", ([FromServices] DAL<Personagem> dal, int id) =>
            {

                var personagem = dal.ReadByName(h => h.Id == id);
                if (personagem is null)
                {
                    return Results.NotFound();
                }
                dal.Delete(personagem);
                return Results.NoContent();

            });

            groupBuilder.MapPut("", ([FromServices] DAL<Personagem> dal, [FromBody] PersonagemEditRequest personagemEditRequest) =>
            {

                var personagemToEdit = dal.ReadByName(h => h.Id == personagemEditRequest.Id);
                if (personagemToEdit is null)
                {
                    return Results.NotFound();
                }
                personagemToEdit.Name = personagemEditRequest.Name;
                personagemToEdit.Nivel = personagemEditRequest.Nivel;
                personagemToEdit.Vida = personagemEditRequest.Vida;
                dal.Update(personagemToEdit);
                return Results.Ok();
            });
        }

        private static ICollection<PersonagemResponse> EntityListToResponseList(IEnumerable<Personagem> personagemList)
        {
            return personagemList.Select(a => EntityToResponse(a)).ToList();

        }

        private static PersonagemResponse EntityToResponse(Personagem a)
        {
            return new PersonagemResponse(a.Id, a.Name, a.Vida, a.Nivel);
        }
    }
}