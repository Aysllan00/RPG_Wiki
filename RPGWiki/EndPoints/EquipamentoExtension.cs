using Microsoft.AspNetCore.Mvc;
using RPGWiki.Requests;
using RPGWiki.Responses;
using RPGWiki.Shared.Data.BD;
using RPGWiki.Shared.Models;
using RPGWiki_Console;

namespace RPGWiki.EndPoints
{
    public static class EquipamentoExtension
    {

        public static void AddEndPointsEquipamento(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("equipamentos").RequireAuthorization().WithTags("Equipamento");

            groupBuilder.MapGet("", ([FromServices] DAL<Equipamento> dal) =>
            {

                var equipamentoList = dal.Read();
                if (equipamentoList is null) return Results.NotFound();

                var equipamentoResponseList = EntityListToResponseList(equipamentoList);
                return Results.Ok(equipamentoResponseList);
            });

            groupBuilder.MapGet("/{id}", ([FromServices] DAL<Equipamento> dal, int id) =>
            {

                var equipamento = dal.ReadByName(h => h.Id == id);
                if (equipamento is null) return Results.NotFound();
                return Results.Ok(EntityToResponse(equipamento));
            });

            groupBuilder.MapPost("", ([FromServices] DAL<Equipamento> dal, [FromBody] EquipamentoRequest equipamentoRequest) =>
            {

                var equipamento = new Equipamento(equipamentoRequest.Name, equipamentoRequest.Tipo);
                dal.Create(equipamento);
                return Results.Ok();
            });

            groupBuilder.MapDelete("/{id}", ([FromServices] DAL<Equipamento> dal, int id) =>
            {

                var equipamento = dal.ReadByName(h => h.Id == id);
                if (equipamento is null)
                {
                    return Results.NotFound();
                }
                dal.Delete(equipamento);
                return Results.NoContent();

            });

            groupBuilder.MapPut("", ([FromServices] DAL<Equipamento> dal, [FromBody] EquipamentoEditRequest equipamentoEditRequest) =>
            {

                var equipamentoToEdit = dal.ReadByName(h => h.Id == equipamentoEditRequest.Id);
                if (equipamentoToEdit is null)
                {
                    return Results.NotFound();
                }
                equipamentoToEdit.Name = equipamentoEditRequest.Name;
                equipamentoToEdit.Tipo = equipamentoEditRequest.Tipo;
                dal.Update(equipamentoToEdit);
                return Results.Ok();
            });
        }

        private static ICollection<EquipamentoResponse> EntityListToResponseList(IEnumerable<Equipamento> equipamentoList)
        {
            return equipamentoList.Select(a => EntityToResponse(a)).ToList();

        }

        private static EquipamentoResponse EntityToResponse(Equipamento a)
        {
            return new EquipamentoResponse(a.Id, a.Name, a.Tipo);
        }
    }
}