using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatregeef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "laboratorio",
                columns: new[] { "Id", "Direccion", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "cll 32 a", "fabio", "5454" },
                    { 2, "# trs 787", "carlos", "767676" },
                    { 3, "esquina 87 cll", "pri", "231323" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "laboratorio",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "laboratorio",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "laboratorio",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
