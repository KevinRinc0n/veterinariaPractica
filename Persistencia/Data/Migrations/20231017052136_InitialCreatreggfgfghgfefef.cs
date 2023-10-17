using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatreggfgfghgfefef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "medicamento",
                columns: new[] { "Id", "IdLaboratorioFk", "Nombre", "Precio", "Stock" },
                values: new object[] { 9, 2, "Dolex", 23.120000000000001, 4 });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "medicamento",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "cita",
                keyColumn: "Id",
                keyValue: 1,
                column: "HoraCita",
                value: new TimeSpan(1292055310));

            migrationBuilder.UpdateData(
                table: "cita",
                keyColumn: "Id",
                keyValue: 2,
                column: "HoraCita",
                value: new TimeSpan(1292055328));

            migrationBuilder.UpdateData(
                table: "cita",
                keyColumn: "Id",
                keyValue: 3,
                column: "HoraCita",
                value: new TimeSpan(1292055330));

            migrationBuilder.UpdateData(
                table: "cita",
                keyColumn: "Id",
                keyValue: 4,
                column: "HoraCita",
                value: new TimeSpan(1292055331));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 17, 0, 2, 9, 207, DateTimeKind.Local).AddTicks(5116));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 17, 0, 2, 9, 207, DateTimeKind.Local).AddTicks(5120));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 17, 0, 2, 9, 207, DateTimeKind.Local).AddTicks(5121));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 17, 0, 2, 9, 207, DateTimeKind.Local).AddTicks(5123));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 17, 0, 2, 9, 207, DateTimeKind.Local).AddTicks(5124));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 17, 0, 2, 9, 207, DateTimeKind.Local).AddTicks(5125));

            migrationBuilder.UpdateData(
                table: "movimientoMedicamento",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaMovimiento",
                value: new DateTime(2023, 10, 17, 0, 2, 9, 208, DateTimeKind.Local).AddTicks(9969));

            migrationBuilder.UpdateData(
                table: "movimientoMedicamento",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaMovimiento",
                value: new DateTime(2023, 10, 17, 0, 2, 9, 208, DateTimeKind.Local).AddTicks(9974));

            migrationBuilder.UpdateData(
                table: "movimientoMedicamento",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaMovimiento",
                value: new DateTime(2023, 10, 17, 0, 2, 9, 208, DateTimeKind.Local).AddTicks(9975));

            migrationBuilder.UpdateData(
                table: "movimientoMedicamento",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaMovimiento",
                value: new DateTime(2023, 10, 17, 0, 2, 9, 208, DateTimeKind.Local).AddTicks(9977));

            migrationBuilder.UpdateData(
                table: "movimientoMedicamento",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaMovimiento",
                value: new DateTime(2023, 10, 17, 0, 2, 9, 208, DateTimeKind.Local).AddTicks(9978));

            migrationBuilder.UpdateData(
                table: "tratamientoMedico",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaAdministracion",
                value: new DateTime(2023, 10, 17, 0, 2, 9, 211, DateTimeKind.Local).AddTicks(814));

            migrationBuilder.UpdateData(
                table: "tratamientoMedico",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaAdministracion",
                value: new DateTime(2023, 10, 17, 0, 2, 9, 211, DateTimeKind.Local).AddTicks(821));

            migrationBuilder.UpdateData(
                table: "tratamientoMedico",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaAdministracion",
                value: new DateTime(2023, 10, 17, 0, 2, 9, 211, DateTimeKind.Local).AddTicks(822));
        }
    }
}
