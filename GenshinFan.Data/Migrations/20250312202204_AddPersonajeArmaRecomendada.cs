using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenshinFan.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPersonajeArmaRecomendada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonajeArmaRecomendada",
                columns: table => new
                {
                    PersonajeId = table.Column<int>(type: "int", nullable: false),
                    ArmaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonajeArmaRecomendada", x => new { x.PersonajeId, x.ArmaId });
                    table.ForeignKey(
                        name: "FK_PersonajeArmaRecomendada_Armas_ArmaId",
                        column: x => x.ArmaId,
                        principalTable: "Armas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonajeArmaRecomendada_Personaje_PersonajeId",
                        column: x => x.PersonajeId,
                        principalTable: "Personaje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonajeArmaRecomendada_ArmaId",
                table: "PersonajeArmaRecomendada",
                column: "ArmaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonajeArmaRecomendada");
        }
    }
}
