using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenshinFan.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AtaqueBase = table.Column<int>(type: "int", nullable: true),
                    Rareza = table.Column<int>(type: "int", nullable: true),
                    ImagenURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Elemento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagenURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elemento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagenURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDeArma",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagenURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeArma", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personaje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rareza = table.Column<int>(type: "int", nullable: true),
                    AtkBase = table.Column<int>(type: "int", nullable: true),
                    DefBase = table.Column<int>(type: "int", nullable: true),
                    VidaBase = table.Column<int>(type: "int", nullable: true),
                    ImgTarjeta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgDisenio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_Elemento = table.Column<int>(type: "int", nullable: true),
                    Id_Region = table.Column<int>(type: "int", nullable: true),
                    Id_TipoDeArma = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personaje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personaje_Elemento_Id_Elemento",
                        column: x => x.Id_Elemento,
                        principalTable: "Elemento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Personaje_Region_Id_Region",
                        column: x => x.Id_Region,
                        principalTable: "Region",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Personaje_TipoDeArma_Id_TipoDeArma",
                        column: x => x.Id_TipoDeArma,
                        principalTable: "TipoDeArma",
                        principalColumn: "Id");
                });

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
                name: "IX_Personaje_Id_Elemento",
                table: "Personaje",
                column: "Id_Elemento");

            migrationBuilder.CreateIndex(
                name: "IX_Personaje_Id_Region",
                table: "Personaje",
                column: "Id_Region");

            migrationBuilder.CreateIndex(
                name: "IX_Personaje_Id_TipoDeArma",
                table: "Personaje",
                column: "Id_TipoDeArma");

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

            migrationBuilder.DropTable(
                name: "Armas");

            migrationBuilder.DropTable(
                name: "Personaje");

            migrationBuilder.DropTable(
                name: "Elemento");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "TipoDeArma");
        }
    }
}
