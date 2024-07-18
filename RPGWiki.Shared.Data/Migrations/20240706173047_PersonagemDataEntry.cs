using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGWiki.Shared.Data.Migrations
{
    public partial class PersonagemDataEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Personagem", new string[] {"Name", "Nivel", "Vida", "JogadorId"}, new object[] {"Arqueiro", 10, 80, 1});
            migrationBuilder.InsertData("Personagem", new string[] { "Name", "Nivel", "Vida", "JogadorId" }, new object[] { "Guerreiro", 6, 100, 3 });
            migrationBuilder.InsertData("Personagem", new string[] { "Name", "Nivel", "Vida", "JogadorId" }, new object[] { "Mago", 12, 60, 2 });
            migrationBuilder.InsertData("Personagem", new string[] { "Name", "Nivel", "Vida", "JogadorId" }, new object[] { "Druida", 9, 70, 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
