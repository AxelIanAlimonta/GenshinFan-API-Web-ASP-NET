using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenshinFan.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameDescripcionToNombreInRegion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Region",
                newName: "Nombre");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Region",
                newName: "Descripcion");
        }
    }
}
