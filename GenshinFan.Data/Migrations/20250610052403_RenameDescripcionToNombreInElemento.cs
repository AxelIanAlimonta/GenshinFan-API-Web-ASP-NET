using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenshinFan.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameDescripcionToNombreInElemento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Elemento",
                newName: "Nombre");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Elemento",
                newName: "Descripcion");
        }
    }
}
