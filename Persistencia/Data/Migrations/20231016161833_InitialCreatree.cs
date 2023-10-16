using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatree : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "Contraseña", "Email", "Nombre" },
                values: new object[,]
                {
                    { 1, "1234", "kevin@gmail.com", "Kevin" },
                    { 2, "1234", "user@gmail.com", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
