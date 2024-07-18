using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGWiki.Shared.Data.Migrations
{
    public partial class InitialDataEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Jogador", new string[] {"Nome", "Moedas"}, new object[] {"Ana", "1500"});
            migrationBuilder.InsertData("Jogador", new string[] { "Nome", "Moedas" }, new object[] { "Bruno", "2000" });
            migrationBuilder.InsertData("Jogador", new string[] { "Nome", "Moedas" }, new object[] { "Carla", "1800" });
            migrationBuilder.InsertData("Jogador", new string[] { "Nome", "Moedas" }, new object[] { "Thomas", "1000" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Jogador");
        }
    }
}
