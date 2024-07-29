using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGWiki.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class RelateJogadorMissao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Missoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dificuldade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JogadorMissao",
                columns: table => new
                {
                    jogadoresId = table.Column<int>(type: "int", nullable: false),
                    missoesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JogadorMissao", x => new { x.jogadoresId, x.missoesId });
                    table.ForeignKey(
                        name: "FK_JogadorMissao_Jogador_jogadoresId",
                        column: x => x.jogadoresId,
                        principalTable: "Jogador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JogadorMissao_Missoes_missoesId",
                        column: x => x.missoesId,
                        principalTable: "Missoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JogadorMissao_missoesId",
                table: "JogadorMissao",
                column: "missoesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JogadorMissao");

            migrationBuilder.DropTable(
                name: "Missoes");
        }
    }
}
