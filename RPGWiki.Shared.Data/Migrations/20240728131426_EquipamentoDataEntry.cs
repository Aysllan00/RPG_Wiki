using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGWiki.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class EquipamentoDataEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Equipamento", new string[] { "Name", "Tipo", "JogadorId" }, new object[] { "Arco", "Arma", 1 });
            migrationBuilder.InsertData("Equipamento", new string[] { "Name", "Tipo", "JogadorId" }, new object[] { "Espada", "Arma", 3 });
            migrationBuilder.InsertData("Equipamento", new string[] { "Name", "Tipo", "JogadorId" }, new object[] { "Poção de Vida", "Consumível", 2 });
            migrationBuilder.InsertData("Equipamento", new string[] { "Name", "Tipo", "JogadorId" }, new object[] { "Escudo", "Armadura",  4 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
