using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGWiki.Shared.Data.Migrations
{
    public partial class RelateJogadorPersonagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JogadorId",
                table: "Personagem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personagem_JogadorId",
                table: "Personagem",
                column: "JogadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personagem_Jogador_JogadorId",
                table: "Personagem",
                column: "JogadorId",
                principalTable: "Jogador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personagem_Jogador_JogadorId",
                table: "Personagem");

            migrationBuilder.DropIndex(
                name: "IX_Personagem_JogadorId",
                table: "Personagem");

            migrationBuilder.DropColumn(
                name: "JogadorId",
                table: "Personagem");
        }
    }
}
