using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatreggfgheef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 16, 20, 21, 20, 723, DateTimeKind.Local).AddTicks(7087));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 16, 20, 21, 20, 723, DateTimeKind.Local).AddTicks(7106));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 16, 20, 21, 20, 723, DateTimeKind.Local).AddTicks(7107));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 16, 20, 21, 20, 723, DateTimeKind.Local).AddTicks(7134));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 16, 20, 21, 20, 723, DateTimeKind.Local).AddTicks(7135));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 16, 20, 21, 20, 723, DateTimeKind.Local).AddTicks(7136));

            migrationBuilder.InsertData(
                table: "tratamientoMedico",
                columns: new[] { "Id", "Dosis", "FechaAdministracion", "Observacion" },
                values: new object[,]
                {
                    { 1, "33.3 mlg", new DateTime(2023, 10, 16, 20, 21, 20, 727, DateTimeKind.Local).AddTicks(6467), "presenta contuciones" },
                    { 2, "2 tabletas", new DateTime(2023, 10, 16, 20, 21, 20, 727, DateTimeKind.Local).AddTicks(6476), "una cada 12 horas" },
                    { 3, "123.9 mlg", new DateTime(2023, 10, 16, 20, 21, 20, 727, DateTimeKind.Local).AddTicks(6477), "solo una inyeccion al dia" }
                });

            migrationBuilder.InsertData(
                table: "tratamientoMedicamento",
                columns: new[] { "IdMedicamentoFk", "IdTratamientoFk", "Id" },
                values: new object[,]
                {
                    { 5, 1, 1 },
                    { 2, 2, 2 },
                    { 4, 3, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tratamientoMedicamento",
                keyColumns: new[] { "IdMedicamentoFk", "IdTratamientoFk" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "tratamientoMedicamento",
                keyColumns: new[] { "IdMedicamentoFk", "IdTratamientoFk" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "tratamientoMedicamento",
                keyColumns: new[] { "IdMedicamentoFk", "IdTratamientoFk" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "tratamientoMedico",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tratamientoMedico",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tratamientoMedico",
                keyColumn: "Id",
                keyValue: 3);

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
        }
    }
}
