using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenshinFan.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddArmaForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoDeArmaId",
                table: "Armas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Armas_TipoDeArmaId",
                table: "Armas",
                column: "TipoDeArmaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Armas_TipoDeArma_TipoDeArmaId",
                table: "Armas",
                column: "TipoDeArmaId",
                principalTable: "TipoDeArma",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Armas_TipoDeArma_TipoDeArmaId",
                table: "Armas");

            migrationBuilder.DropIndex(
                name: "IX_Armas_TipoDeArmaId",
                table: "Armas");

            migrationBuilder.DropColumn(
                name: "TipoDeArmaId",
                table: "Armas");
        }
    }
}
