using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatreeef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "veterinario",
                columns: new[] { "Id", "Email", "Especialidad", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "maria@gmail.com", "cirujano vascular", "maria", "1234" },
                    { 2, "jose@gmail.com", "castrador", "jose", "1234567" },
                    { 3, "saul@gmail.com", "cirujano vascular", "saul", "1234444" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "veterinario",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "veterinario",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "veterinario",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
