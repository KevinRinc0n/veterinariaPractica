using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatregggeef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "especie",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Felino" },
                    { 2, "Anfibio" },
                    { 3, "Reptil" }
                });

            migrationBuilder.InsertData(
                table: "propietario",
                columns: new[] { "Id", "Email", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "pri@gmail.com", "pri", "3213" },
                    { 2, "raul@gmail.com", "raul", "54545" },
                    { 3, "stiven@gmail.com", "stiven", "87878" }
                });

            migrationBuilder.InsertData(
                table: "raza",
                columns: new[] { "Id", "IdEspecieFk", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, "gato" },
                    { 2, 1, "tigre" },
                    { 3, 1, "puma" },
                    { 4, 2, "rana" },
                    { 5, 3, "salamandra" },
                    { 6, 3, "cocodrilo" }
                });

            migrationBuilder.InsertData(
                table: "mascota",
                columns: new[] { "Id", "FechaNacimiento", "IdEspecieFk", "IdPropietarioFk", "IdRazaFk", "Nombre" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 16, 18, 45, 59, 4, DateTimeKind.Local).AddTicks(4312), 1, 1, 1, "michi" },
                    { 2, new DateTime(2023, 10, 16, 18, 45, 59, 4, DateTimeKind.Local).AddTicks(4328), 1, 1, 1, "gato" },
                    { 3, new DateTime(2023, 10, 16, 18, 45, 59, 4, DateTimeKind.Local).AddTicks(4330), 2, 3, 1, "firulais" },
                    { 4, new DateTime(2023, 10, 16, 18, 45, 59, 4, DateTimeKind.Local).AddTicks(4331), 1, 1, 1, "gato con botas" },
                    { 5, new DateTime(2023, 10, 16, 18, 45, 59, 4, DateTimeKind.Local).AddTicks(4333), 2, 2, 2, "tamara" },
                    { 6, new DateTime(2023, 10, 16, 18, 45, 59, 4, DateTimeKind.Local).AddTicks(4334), 3, 3, 3, "terry" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "raza",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "raza",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "raza",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "especie",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "especie",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "propietario",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "propietario",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "propietario",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "raza",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "raza",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "raza",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "especie",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
