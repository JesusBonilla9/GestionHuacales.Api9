using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GestionHuacales.Api9.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntradasHuacales",
                columns: table => new
                {
                    EntradaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreCliente = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Importe = table.Column<double>(type: "REAL", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradasHuacales", x => x.EntradaId);
                });

            migrationBuilder.CreateTable(
                name: "TiposHuacales",
                columns: table => new
                {
                    TipoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Existencias = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposHuacales", x => x.TipoId);
                });

            migrationBuilder.CreateTable(
                name: "EntradasHuacalesDetalles",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EntradaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Precio = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradasHuacalesDetalles", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_EntradasHuacalesDetalles_EntradasHuacales_EntradaId",
                        column: x => x.EntradaId,
                        principalTable: "EntradasHuacales",
                        principalColumn: "EntradaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TiposHuacales",
                columns: new[] { "TipoId", "Descripcion", "Existencias" },
                values: new object[,]
                {
                    { 1, "Rojo Grande", 0 },
                    { 2, "Rojo Mediano", 0 },
                    { 3, "Rojo Pequeño", 0 },
                    { 4, "Verde Grande", 0 },
                    { 5, "Verde Mediano", 0 },
                    { 6, "Verde Pequeño", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntradasHuacalesDetalles_EntradaId",
                table: "EntradasHuacalesDetalles",
                column: "EntradaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntradasHuacalesDetalles");

            migrationBuilder.DropTable(
                name: "TiposHuacales");

            migrationBuilder.DropTable(
                name: "EntradasHuacales");
        }
    }
}
