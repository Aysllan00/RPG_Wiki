using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGWiki.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class MissoesDataEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Missoes", new string[] { "Id", "Name", "Dificuldade" }, new object[] { 1, "Resgatar o Rei", 3 });
            migrationBuilder.InsertData("Missoes", new string[] { "Id", "Name", "Dificuldade" }, new object[] { 2, "Defender a Vila", 5 });
            migrationBuilder.InsertData("Missoes", new string[] { "Id", "Name", "Dificuldade" }, new object[] { 3, "Explorar a Caverna", 1 });

            migrationBuilder.InsertData("JogadorMissao", new string[] { "jogadoresId", "missoesId" }, new object[] { 1, 1 });
            migrationBuilder.InsertData("JogadorMissao", new string[] { "jogadoresId", "missoesId" }, new object[] { 2, 1 });
            migrationBuilder.InsertData("JogadorMissao", new string[] { "jogadoresId", "missoesId" }, new object[] { 3, 2 });
            migrationBuilder.InsertData("JogadorMissao", new string[] { "jogadoresId", "missoesId" }, new object[] { 2, 2 });
            migrationBuilder.InsertData("JogadorMissao", new string[] { "jogadoresId", "missoesId" }, new object[] { 4, 3 });
            migrationBuilder.InsertData("JogadorMissao", new string[] { "jogadoresId", "missoesId" }, new object[] { 3, 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
