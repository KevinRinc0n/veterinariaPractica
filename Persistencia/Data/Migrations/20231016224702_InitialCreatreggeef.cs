using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatreggeef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "laboratorio",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "laboratorio",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nombre",
                value: "Genfar");

            migrationBuilder.UpdateData(
                table: "laboratorio",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nombre",
                value: "MK");

            migrationBuilder.InsertData(
                table: "medicamento",
                columns: new[] { "Id", "IdLaboratorioFk", "Nombre", "Precio", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "Clonazepan", 33.399999999999999, 34 },
                    { 2, 1, "Dolex", 12.119999999999999, 2 },
                    { 3, 1, "Acetaminofen", 1.54, 55 },
                    { 4, 2, "Jarabe para la tos", 9.8900000000000006, 1 },
                    { 5, 2, "Dolex Liquido", 543.5, 98 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "medicamento",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "medicamento",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "medicamento",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "medicamento",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "medicamento",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "laboratorio",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nombre",
                value: "fabio");

            migrationBuilder.UpdateData(
                table: "laboratorio",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nombre",
                value: "carlos");

            migrationBuilder.InsertData(
                table: "laboratorio",
                columns: new[] { "Id", "Direccion", "Nombre", "Telefono" },
                values: new object[] { 3, "esquina 87 cll", "pri", "231323" });
        }
    }
}
