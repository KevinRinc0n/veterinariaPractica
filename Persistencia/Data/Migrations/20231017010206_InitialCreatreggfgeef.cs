using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatreggfgeef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 16, 20, 2, 6, 580, DateTimeKind.Local).AddTicks(5055));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 16, 20, 2, 6, 580, DateTimeKind.Local).AddTicks(5074));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 16, 20, 2, 6, 580, DateTimeKind.Local).AddTicks(5075));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 16, 20, 2, 6, 580, DateTimeKind.Local).AddTicks(5076));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 16, 20, 2, 6, 580, DateTimeKind.Local).AddTicks(5077));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 16, 20, 2, 6, 580, DateTimeKind.Local).AddTicks(5079));

            migrationBuilder.InsertData(
                table: "medicamento",
                columns: new[] { "Id", "IdLaboratorioFk", "Nombre", "Precio", "Stock" },
                values: new object[,]
                {
                    { 6, 2, "Diclofenaco", 6000.0, 14 },
                    { 7, 2, "Naproxeno", 7000.0, 31 },
                    { 8, 2, "Loratadina ", 5001.0, 21 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "medicamento",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "medicamento",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "medicamento",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 16, 18, 45, 59, 4, DateTimeKind.Local).AddTicks(4312));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 16, 18, 45, 59, 4, DateTimeKind.Local).AddTicks(4328));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 16, 18, 45, 59, 4, DateTimeKind.Local).AddTicks(4330));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 16, 18, 45, 59, 4, DateTimeKind.Local).AddTicks(4331));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 16, 18, 45, 59, 4, DateTimeKind.Local).AddTicks(4333));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 16, 18, 45, 59, 4, DateTimeKind.Local).AddTicks(4334));
        }
    }
}
