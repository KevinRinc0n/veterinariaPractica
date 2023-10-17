using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatreggfgfghgfgefef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "cita",
                keyColumn: "Id",
                keyValue: 1,
                column: "HoraCita",
                value: new TimeSpan(18961521858));

            migrationBuilder.UpdateData(
                table: "cita",
                keyColumn: "Id",
                keyValue: 2,
                column: "HoraCita",
                value: new TimeSpan(18961521873));

            migrationBuilder.UpdateData(
                table: "cita",
                keyColumn: "Id",
                keyValue: 3,
                column: "HoraCita",
                value: new TimeSpan(18961521874));

            migrationBuilder.UpdateData(
                table: "cita",
                keyColumn: "Id",
                keyValue: 4,
                column: "HoraCita",
                value: new TimeSpan(18961521876));

            migrationBuilder.InsertData(
                table: "especie",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 4, "Canino" });

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 17, 0, 31, 36, 154, DateTimeKind.Local).AddTicks(2526));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 17, 0, 31, 36, 154, DateTimeKind.Local).AddTicks(2531));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 17, 0, 31, 36, 154, DateTimeKind.Local).AddTicks(2532));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 17, 0, 31, 36, 154, DateTimeKind.Local).AddTicks(2534));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 17, 0, 31, 36, 154, DateTimeKind.Local).AddTicks(2535));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 17, 0, 31, 36, 154, DateTimeKind.Local).AddTicks(2536));

            migrationBuilder.UpdateData(
                table: "movimientoMedicamento",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaMovimiento",
                value: new DateTime(2023, 10, 17, 0, 31, 36, 155, DateTimeKind.Local).AddTicks(8748));

            migrationBuilder.UpdateData(
                table: "movimientoMedicamento",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaMovimiento",
                value: new DateTime(2023, 10, 17, 0, 31, 36, 155, DateTimeKind.Local).AddTicks(8752));

            migrationBuilder.UpdateData(
                table: "movimientoMedicamento",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaMovimiento",
                value: new DateTime(2023, 10, 17, 0, 31, 36, 155, DateTimeKind.Local).AddTicks(8754));

            migrationBuilder.UpdateData(
                table: "movimientoMedicamento",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaMovimiento",
                value: new DateTime(2023, 10, 17, 0, 31, 36, 155, DateTimeKind.Local).AddTicks(8755));

            migrationBuilder.UpdateData(
                table: "movimientoMedicamento",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaMovimiento",
                value: new DateTime(2023, 10, 17, 0, 31, 36, 155, DateTimeKind.Local).AddTicks(8756));

            migrationBuilder.UpdateData(
                table: "tratamientoMedico",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaAdministracion",
                value: new DateTime(2023, 10, 17, 0, 31, 36, 158, DateTimeKind.Local).AddTicks(1436));

            migrationBuilder.UpdateData(
                table: "tratamientoMedico",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaAdministracion",
                value: new DateTime(2023, 10, 17, 0, 31, 36, 158, DateTimeKind.Local).AddTicks(1441));

            migrationBuilder.UpdateData(
                table: "tratamientoMedico",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaAdministracion",
                value: new DateTime(2023, 10, 17, 0, 31, 36, 158, DateTimeKind.Local).AddTicks(1442));

            migrationBuilder.InsertData(
                table: "raza",
                columns: new[] { "Id", "IdEspecieFk", "Nombre" },
                values: new object[] { 7, 4, "Golden Retriver" });

            migrationBuilder.InsertData(
                table: "mascota",
                columns: new[] { "Id", "FechaNacimiento", "IdEspecieFk", "IdPropietarioFk", "IdRazaFk", "Nombre" },
                values: new object[,]
                {
                    { 7, new DateTime(2023, 10, 17, 0, 31, 36, 154, DateTimeKind.Local).AddTicks(2537), 4, 3, 7, "max" },
                    { 8, new DateTime(2023, 10, 17, 0, 31, 36, 154, DateTimeKind.Local).AddTicks(2538), 4, 1, 7, "rokcy" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "raza",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "especie",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "cita",
                keyColumn: "Id",
                keyValue: 1,
                column: "HoraCita",
                value: new TimeSpan(12967201391));

            migrationBuilder.UpdateData(
                table: "cita",
                keyColumn: "Id",
                keyValue: 2,
                column: "HoraCita",
                value: new TimeSpan(12967201405));

            migrationBuilder.UpdateData(
                table: "cita",
                keyColumn: "Id",
                keyValue: 3,
                column: "HoraCita",
                value: new TimeSpan(12967201406));

            migrationBuilder.UpdateData(
                table: "cita",
                keyColumn: "Id",
                keyValue: 4,
                column: "HoraCita",
                value: new TimeSpan(12967201408));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 17, 0, 21, 36, 722, DateTimeKind.Local).AddTicks(2541));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 17, 0, 21, 36, 722, DateTimeKind.Local).AddTicks(2545));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 17, 0, 21, 36, 722, DateTimeKind.Local).AddTicks(2546));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 17, 0, 21, 36, 722, DateTimeKind.Local).AddTicks(2548));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 17, 0, 21, 36, 722, DateTimeKind.Local).AddTicks(2549));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 17, 0, 21, 36, 722, DateTimeKind.Local).AddTicks(2550));

            migrationBuilder.UpdateData(
                table: "movimientoMedicamento",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaMovimiento",
                value: new DateTime(2023, 10, 17, 0, 21, 36, 723, DateTimeKind.Local).AddTicks(8222));

            migrationBuilder.UpdateData(
                table: "movimientoMedicamento",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaMovimiento",
                value: new DateTime(2023, 10, 17, 0, 21, 36, 723, DateTimeKind.Local).AddTicks(8226));

            migrationBuilder.UpdateData(
                table: "movimientoMedicamento",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaMovimiento",
                value: new DateTime(2023, 10, 17, 0, 21, 36, 723, DateTimeKind.Local).AddTicks(8228));

            migrationBuilder.UpdateData(
                table: "movimientoMedicamento",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaMovimiento",
                value: new DateTime(2023, 10, 17, 0, 21, 36, 723, DateTimeKind.Local).AddTicks(8229));

            migrationBuilder.UpdateData(
                table: "movimientoMedicamento",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaMovimiento",
                value: new DateTime(2023, 10, 17, 0, 21, 36, 723, DateTimeKind.Local).AddTicks(8230));

            migrationBuilder.UpdateData(
                table: "tratamientoMedico",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaAdministracion",
                value: new DateTime(2023, 10, 17, 0, 21, 36, 726, DateTimeKind.Local).AddTicks(13));

            migrationBuilder.UpdateData(
                table: "tratamientoMedico",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaAdministracion",
                value: new DateTime(2023, 10, 17, 0, 21, 36, 726, DateTimeKind.Local).AddTicks(18));

            migrationBuilder.UpdateData(
                table: "tratamientoMedico",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaAdministracion",
                value: new DateTime(2023, 10, 17, 0, 21, 36, 726, DateTimeKind.Local).AddTicks(19));
        }
    }
}
