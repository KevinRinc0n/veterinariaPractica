using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatreggfgfghefef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "tipoMovimiento",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Venta" },
                    { 2, "Compra" }
                });

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

            migrationBuilder.InsertData(
                table: "movimientoMedicamento",
                columns: new[] { "Id", "Cantidad", "CostoTotal", "FechaMovimiento", "IdMedicamentoFk", "IdTipoMovimientoFk" },
                values: new object[,]
                {
                    { 1, 3, "33.3", new DateTime(2023, 10, 17, 0, 2, 9, 208, DateTimeKind.Local).AddTicks(9969), 1, 1 },
                    { 2, 1, "65.3", new DateTime(2023, 10, 17, 0, 2, 9, 208, DateTimeKind.Local).AddTicks(9974), 1, 2 },
                    { 3, 2, "7000", new DateTime(2023, 10, 17, 0, 2, 9, 208, DateTimeKind.Local).AddTicks(9975), 2, 2 },
                    { 4, 3, "6546.8", new DateTime(2023, 10, 17, 0, 2, 9, 208, DateTimeKind.Local).AddTicks(9977), 3, 1 },
                    { 5, 3, "2500", new DateTime(2023, 10, 17, 0, 2, 9, 208, DateTimeKind.Local).AddTicks(9978), 2, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "movimientoMedicamento",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "movimientoMedicamento",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "movimientoMedicamento",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "movimientoMedicamento",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "movimientoMedicamento",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "tipoMovimiento",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tipoMovimiento",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "cita",
                keyColumn: "Id",
                keyValue: 1,
                column: "HoraCita",
                value: new TimeSpan(827866543332));

            migrationBuilder.UpdateData(
                table: "cita",
                keyColumn: "Id",
                keyValue: 2,
                column: "HoraCita",
                value: new TimeSpan(827866543346));

            migrationBuilder.UpdateData(
                table: "cita",
                keyColumn: "Id",
                keyValue: 3,
                column: "HoraCita",
                value: new TimeSpan(827866543347));

            migrationBuilder.UpdateData(
                table: "cita",
                keyColumn: "Id",
                keyValue: 4,
                column: "HoraCita",
                value: new TimeSpan(827866543349));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 16, 22, 59, 46, 656, DateTimeKind.Local).AddTicks(4930));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 16, 22, 59, 46, 656, DateTimeKind.Local).AddTicks(4936));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 16, 22, 59, 46, 656, DateTimeKind.Local).AddTicks(4937));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 16, 22, 59, 46, 656, DateTimeKind.Local).AddTicks(4938));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 16, 22, 59, 46, 656, DateTimeKind.Local).AddTicks(4939));

            migrationBuilder.UpdateData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaNacimiento",
                value: new DateTime(2023, 10, 16, 22, 59, 46, 656, DateTimeKind.Local).AddTicks(4941));

            migrationBuilder.UpdateData(
                table: "tratamientoMedico",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaAdministracion",
                value: new DateTime(2023, 10, 16, 22, 59, 46, 660, DateTimeKind.Local).AddTicks(3201));

            migrationBuilder.UpdateData(
                table: "tratamientoMedico",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaAdministracion",
                value: new DateTime(2023, 10, 16, 22, 59, 46, 660, DateTimeKind.Local).AddTicks(3208));

            migrationBuilder.UpdateData(
                table: "tratamientoMedico",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaAdministracion",
                value: new DateTime(2023, 10, 16, 22, 59, 46, 660, DateTimeKind.Local).AddTicks(3209));
        }
    }
}
