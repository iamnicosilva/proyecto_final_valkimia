using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TorneoTenis.API.Migrations
{
    /// <inheritdoc />
    public partial class tablausuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiration = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

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
                    Eliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Genero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jugador_Genero_Genero",
                        column: x => x.Genero,
                        principalTable: "Genero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Torneo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Año = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Genero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Torneo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Torneo_Genero_Genero",
                        column: x => x.Genero,
                        principalTable: "Genero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Partido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Etapa = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    Ganador = table.Column<int>(type: "int", nullable: false),
                    Perdedor = table.Column<int>(type: "int", nullable: false),
                    Torneo = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.InsertData(
                table: "Genero",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 1, "Femenino", "Mujer" },
                    { 2, "Masculino", "Hombre" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jugador_Genero",
                table: "Jugador",
                column: "Genero");

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

            migrationBuilder.CreateIndex(
                name: "IX_Torneo_Genero",
                table: "Torneo",
                column: "Genero");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Partido");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Jugador");

            migrationBuilder.DropTable(
                name: "Torneo");

            migrationBuilder.DropTable(
                name: "Genero");
        }
    }
}
