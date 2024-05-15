using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TorneoTenis.API.Migrations
{
    /// <inheritdoc />
    public partial class act_torneogenero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jugador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Habilidad = table.Column<int>(type: "int", maxLength: 3, nullable: false, defaultValue: 0),
                    Fuerza = table.Column<int>(type: "int", maxLength: 3, nullable: false, defaultValue: 0),
                    Velocidad = table.Column<int>(type: "int", maxLength: 3, nullable: false, defaultValue: 0),
                    Reaccion = table.Column<int>(type: "int", maxLength: 3, nullable: false, defaultValue: 0),
                    EsHombre = table.Column<bool>(type: "bit", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Torneo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Año = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    EsTorneoMasculino = table.Column<bool>(name: "Es Torneo Masculino", type: "bit", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Torneo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Etapa = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", maxLength: 100, nullable: false),
                    DescripcionGanador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ganador = table.Column<int>(type: "int", nullable: false),
                    Perdedor = table.Column<int>(type: "int", nullable: false),
                    Torneo = table.Column<int>(type: "int", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partido_Jugador_Ganador",
                        column: x => x.Ganador,
                        principalTable: "Jugador",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Partido_Jugador_Perdedor",
                        column: x => x.Perdedor,
                        principalTable: "Jugador",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Partido_Torneo_Torneo",
                        column: x => x.Torneo,
                        principalTable: "Torneo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Partido_Ganador",
                table: "Partido",
                column: "Ganador");

            migrationBuilder.CreateIndex(
                name: "IX_Partido_Perdedor",
                table: "Partido",
                column: "Perdedor");

            migrationBuilder.CreateIndex(
                name: "IX_Partido_Torneo",
                table: "Partido",
                column: "Torneo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Partido");

            migrationBuilder.DropTable(
                name: "Jugador");

            migrationBuilder.DropTable(
                name: "Torneo");
        }
    }
}
