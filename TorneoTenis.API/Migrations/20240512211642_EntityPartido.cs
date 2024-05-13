using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TorneoTenis.API.Migrations
{
    /// <inheritdoc />
    public partial class EntityPartido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                table: "Partido",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "Partido");
        }
    }
}
