using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatreggfgfhefef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "cita",
                columns: new[] { "Id", "FechaCita", "HoraCita", "IdMascotaFk", "IdTratamientoFk", "IdVeterinarioFk", "Motivo" },
                values: new object[] { 3, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(827866543347), 3, 2, 1, "Revision general" });

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

            migrationBuilder.InsertData(
                table: "veterinario",
                columns: new[] { "Id", "Email", "Especialidad", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 4, "paco@gmail.com", "vacunador", "paco", "5454" },
                    { 5, "valentina@gmail.com", "revisiones generales", "valentina", "7644" }
                });

            migrationBuilder.InsertData(
                table: "cita",
                columns: new[] { "Id", "FechaCita", "HoraCita", "IdMascotaFk", "IdTratamientoFk", "IdVeterinarioFk", "Motivo" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(827866543332), 1, 3, 4, "Vacunacion" },
                    { 2, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(827866543346), 4, 1, 5, "Vacunacion" },
                    { 4, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(827866543349), 2, 3, 4, "Vacunacion" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "cita",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "cita",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "cita",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "cita",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "veterinario",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "veterinario",
                keyColumn: "Id",
                keyValue: 5);

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
    }
}
