using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatreggfghefef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 16, 22, 37, 17, 273, DateTimeKind.Local).AddTicks(9929));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 16, 22, 37, 17, 273, DateTimeKind.Local).AddTicks(9948));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 16, 22, 37, 17, 273, DateTimeKind.Local).AddTicks(9949));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 16, 22, 37, 17, 273, DateTimeKind.Local).AddTicks(9950));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 16, 22, 37, 17, 273, DateTimeKind.Local).AddTicks(9951));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 16, 22, 37, 17, 273, DateTimeKind.Local).AddTicks(9952));

            migrationBuilder.UpdateData(
                table: "tratamientoMedico",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaAdministracion",
                value: new DateTime(2023, 10, 16, 22, 37, 17, 277, DateTimeKind.Local).AddTicks(4964));

            migrationBuilder.UpdateData(
                table: "tratamientoMedico",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaAdministracion",
                value: new DateTime(2023, 10, 16, 22, 37, 17, 277, DateTimeKind.Local).AddTicks(4969));

            migrationBuilder.UpdateData(
                table: "tratamientoMedico",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaAdministracion",
                value: new DateTime(2023, 10, 16, 22, 37, 17, 277, DateTimeKind.Local).AddTicks(4970));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "tratamientoMedico",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaAdministracion",
                value: new DateTime(2023, 10, 16, 20, 21, 20, 727, DateTimeKind.Local).AddTicks(6467));

            migrationBuilder.UpdateData(
                table: "tratamientoMedico",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaAdministracion",
                value: new DateTime(2023, 10, 16, 20, 21, 20, 727, DateTimeKind.Local).AddTicks(6476));

            migrationBuilder.UpdateData(
                table: "tratamientoMedico",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaAdministracion",
                value: new DateTime(2023, 10, 16, 20, 21, 20, 727, DateTimeKind.Local).AddTicks(6477));
        }
    }
}
