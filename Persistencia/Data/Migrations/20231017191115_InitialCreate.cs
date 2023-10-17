using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "especie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_especie", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "laboratorio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_laboratorio", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "propietario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_propietario", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "proveedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proveedor", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipoMovimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoMovimiento", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tratamientoMedico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Dosis = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaAdministracion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Observacion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tratamientoMedico", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Contraseña = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "veterinario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Especialidad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veterinario", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "raza",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdEspecieFk = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_raza", x => x.Id);
                    table.ForeignKey(
                        name: "FK_raza_especie_IdEspecieFk",
                        column: x => x.IdEspecieFk,
                        principalTable: "especie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medicamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<double>(type: "double", nullable: false),
                    IdLaboratorioFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicamento_laboratorio_IdLaboratorioFk",
                        column: x => x.IdLaboratorioFk,
                        principalTable: "laboratorio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "producto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<double>(type: "double", nullable: false),
                    IdProveedorFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_producto_proveedor_IdProveedorFk",
                        column: x => x.IdProveedorFk,
                        principalTable: "proveedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "refreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdUserFk = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expires = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_refreshToken_user_IdUserFk",
                        column: x => x.IdUserFk,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usersRols",
                columns: table => new
                {
                    IdUsuarioFk = table.Column<int>(type: "int", nullable: false),
                    IdRolFk = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usersRols", x => new { x.IdUsuarioFk, x.IdRolFk });
                    table.ForeignKey(
                        name: "FK_usersRols_rol_IdRolFk",
                        column: x => x.IdRolFk,
                        principalTable: "rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usersRols_user_IdUsuarioFk",
                        column: x => x.IdUsuarioFk,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "mascota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdPropietarioFk = table.Column<int>(type: "int", nullable: false),
                    IdEspecieFk = table.Column<int>(type: "int", nullable: false),
                    IdRazaFk = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mascota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mascota_especie_IdEspecieFk",
                        column: x => x.IdEspecieFk,
                        principalTable: "especie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mascota_propietario_IdPropietarioFk",
                        column: x => x.IdPropietarioFk,
                        principalTable: "propietario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mascota_raza_IdRazaFk",
                        column: x => x.IdRazaFk,
                        principalTable: "raza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "movimientoMedicamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdTipoMovimientoFk = table.Column<int>(type: "int", nullable: false),
                    IdMedicamentoFk = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    CostoTotal = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaMovimiento = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movimientoMedicamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_movimientoMedicamento_medicamento_IdMedicamentoFk",
                        column: x => x.IdMedicamentoFk,
                        principalTable: "medicamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movimientoMedicamento_tipoMovimiento_IdTipoMovimientoFk",
                        column: x => x.IdTipoMovimientoFk,
                        principalTable: "tipoMovimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tratamientoMedicamento",
                columns: table => new
                {
                    IdTratamientoFk = table.Column<int>(type: "int", nullable: false),
                    IdMedicamentoFk = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tratamientoMedicamento", x => new { x.IdTratamientoFk, x.IdMedicamentoFk });
                    table.ForeignKey(
                        name: "FK_tratamientoMedicamento_medicamento_IdMedicamentoFk",
                        column: x => x.IdMedicamentoFk,
                        principalTable: "medicamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tratamientoMedicamento_tratamientoMedico_IdTratamientoFk",
                        column: x => x.IdTratamientoFk,
                        principalTable: "tratamientoMedico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "clienteProducto",
                columns: table => new
                {
                    IdClienteFk = table.Column<int>(type: "int", nullable: false),
                    IdProductoFk = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clienteProducto", x => new { x.IdClienteFk, x.IdProductoFk });
                    table.ForeignKey(
                        name: "FK_clienteProducto_cliente_IdClienteFk",
                        column: x => x.IdClienteFk,
                        principalTable: "cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_clienteProducto_producto_IdProductoFk",
                        column: x => x.IdProductoFk,
                        principalTable: "producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "movimientoProducto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdTipoMovimientoFk = table.Column<int>(type: "int", nullable: false),
                    IdProductoFk = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    CostoTotal = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaMovimiento = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movimientoProducto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_movimientoProducto_producto_IdProductoFk",
                        column: x => x.IdProductoFk,
                        principalTable: "producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movimientoProducto_tipoMovimiento_IdTipoMovimientoFk",
                        column: x => x.IdTipoMovimientoFk,
                        principalTable: "tipoMovimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdTratamientoFk = table.Column<int>(type: "int", nullable: false),
                    IdMascotaFk = table.Column<int>(type: "int", nullable: false),
                    FechaCita = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    HoraCita = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    Motivo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdVeterinarioFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cita_mascota_IdMascotaFk",
                        column: x => x.IdMascotaFk,
                        principalTable: "mascota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cita_tratamientoMedico_IdTratamientoFk",
                        column: x => x.IdTratamientoFk,
                        principalTable: "tratamientoMedico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cita_veterinario_IdVeterinarioFk",
                        column: x => x.IdVeterinarioFk,
                        principalTable: "veterinario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "especie",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Felino" },
                    { 2, "Anfibio" },
                    { 3, "Reptil" },
                    { 4, "Canino" }
                });

            migrationBuilder.InsertData(
                table: "laboratorio",
                columns: new[] { "Id", "Direccion", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "cll 32 a", "Genfar", "5454" },
                    { 2, "# trs 787", "MK", "767676" }
                });

            migrationBuilder.InsertData(
                table: "propietario",
                columns: new[] { "Id", "Email", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "pri@gmail.com", "pri", "3213" },
                    { 2, "raul@gmail.com", "raul", "54545" },
                    { 3, "stiven@gmail.com", "stiven", "87878" }
                });

            migrationBuilder.InsertData(
                table: "rol",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Empleado" }
                });

            migrationBuilder.InsertData(
                table: "tipoMovimiento",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Venta" },
                    { 2, "Compra" }
                });

            migrationBuilder.InsertData(
                table: "tratamientoMedico",
                columns: new[] { "Id", "Dosis", "FechaAdministracion", "Observacion" },
                values: new object[,]
                {
                    { 1, "33.3 mlg", new DateTime(2023, 10, 17, 14, 11, 15, 568, DateTimeKind.Local).AddTicks(4972), "presenta contuciones" },
                    { 2, "2 tabletas", new DateTime(2023, 10, 17, 14, 11, 15, 568, DateTimeKind.Local).AddTicks(4977), "una cada 12 horas" },
                    { 3, "123.9 mlg", new DateTime(2023, 10, 17, 14, 11, 15, 568, DateTimeKind.Local).AddTicks(4978), "solo una inyeccion al dia" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "Contraseña", "Email", "Nombre" },
                values: new object[,]
                {
                    { 1, "1234", "kevin@gmail.com", "Kevin" },
                    { 2, "1234", "user@gmail.com", "user" }
                });

            migrationBuilder.InsertData(
                table: "veterinario",
                columns: new[] { "Id", "Email", "Especialidad", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "maria@gmail.com", "cirujano vascular", "maria", "1234" },
                    { 2, "jose@gmail.com", "castrador", "jose", "1234567" },
                    { 3, "saul@gmail.com", "cirujano vascular", "saul", "1234444" },
                    { 4, "paco@gmail.com", "vacunador", "paco", "5454" },
                    { 5, "valentina@gmail.com", "revisiones generales", "valentina", "7644" }
                });

            migrationBuilder.InsertData(
                table: "medicamento",
                columns: new[] { "Id", "IdLaboratorioFk", "Nombre", "Precio", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "Clonazepan", 33.399999999999999, 34 },
                    { 2, 1, "Dolex", 12.119999999999999, 2 },
                    { 3, 1, "Acetaminofen", 1.54, 55 },
                    { 4, 2, "Jarabe para la tos", 9.8900000000000006, 1 },
                    { 5, 2, "Dolex Liquido", 543.5, 98 },
                    { 6, 2, "Diclofenaco", 6000.0, 14 },
                    { 7, 2, "Naproxeno", 7000.0, 31 },
                    { 8, 2, "Loratadina ", 5001.0, 21 },
                    { 9, 2, "Dolex", 23.120000000000001, 4 }
                });

            migrationBuilder.InsertData(
                table: "raza",
                columns: new[] { "Id", "IdEspecieFk", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, "gato" },
                    { 2, 1, "tigre" },
                    { 3, 1, "puma" },
                    { 4, 2, "rana" },
                    { 5, 3, "salamandra" },
                    { 6, 3, "cocodrilo" },
                    { 7, 4, "Golden Retriver" }
                });

            migrationBuilder.InsertData(
                table: "mascota",
                columns: new[] { "Id", "FechaNacimiento", "IdEspecieFk", "IdPropietarioFk", "IdRazaFk", "Nombre" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 17, 14, 11, 15, 564, DateTimeKind.Local).AddTicks(7467), 1, 1, 1, "michi" },
                    { 2, new DateTime(2023, 10, 17, 14, 11, 15, 564, DateTimeKind.Local).AddTicks(7476), 1, 1, 1, "gato" },
                    { 3, new DateTime(2023, 10, 17, 14, 11, 15, 564, DateTimeKind.Local).AddTicks(7478), 2, 3, 1, "firulais" },
                    { 4, new DateTime(2023, 10, 17, 14, 11, 15, 564, DateTimeKind.Local).AddTicks(7479), 1, 1, 1, "gato con botas" },
                    { 5, new DateTime(2023, 10, 17, 14, 11, 15, 564, DateTimeKind.Local).AddTicks(7480), 2, 2, 2, "tamara" },
                    { 6, new DateTime(2023, 10, 17, 14, 11, 15, 564, DateTimeKind.Local).AddTicks(7481), 3, 3, 3, "terry" },
                    { 7, new DateTime(2023, 10, 17, 14, 11, 15, 564, DateTimeKind.Local).AddTicks(7482), 4, 3, 7, "max" },
                    { 8, new DateTime(2023, 10, 17, 14, 11, 15, 564, DateTimeKind.Local).AddTicks(7483), 4, 1, 7, "rokcy" }
                });

            migrationBuilder.InsertData(
                table: "movimientoMedicamento",
                columns: new[] { "Id", "Cantidad", "CostoTotal", "FechaMovimiento", "IdMedicamentoFk", "IdTipoMovimientoFk" },
                values: new object[,]
                {
                    { 1, 3, "33.3", new DateTime(2023, 10, 17, 14, 11, 15, 566, DateTimeKind.Local).AddTicks(2915), 1, 1 },
                    { 2, 1, "65.3", new DateTime(2023, 10, 17, 14, 11, 15, 566, DateTimeKind.Local).AddTicks(2920), 1, 2 },
                    { 3, 2, "7000", new DateTime(2023, 10, 17, 14, 11, 15, 566, DateTimeKind.Local).AddTicks(2921), 2, 2 },
                    { 4, 3, "6546.8", new DateTime(2023, 10, 17, 14, 11, 15, 566, DateTimeKind.Local).AddTicks(2922), 3, 1 },
                    { 5, 3, "2500", new DateTime(2023, 10, 17, 14, 11, 15, 566, DateTimeKind.Local).AddTicks(2923), 2, 2 }
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

            migrationBuilder.InsertData(
                table: "cita",
                columns: new[] { "Id", "FechaCita", "HoraCita", "IdMascotaFk", "IdTratamientoFk", "IdVeterinarioFk", "Motivo" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(510755625129), 1, 3, 4, "Vacunacion" },
                    { 2, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(510755625148), 4, 1, 5, "Vacunacion" },
                    { 3, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(510755625150), 3, 2, 1, "Revision general" },
                    { 4, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(510755625152), 2, 3, 4, "Vacunacion" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_cita_IdMascotaFk",
                table: "cita",
                column: "IdMascotaFk");

            migrationBuilder.CreateIndex(
                name: "IX_cita_IdTratamientoFk",
                table: "cita",
                column: "IdTratamientoFk");

            migrationBuilder.CreateIndex(
                name: "IX_cita_IdVeterinarioFk",
                table: "cita",
                column: "IdVeterinarioFk");

            migrationBuilder.CreateIndex(
                name: "IX_clienteProducto_IdProductoFk",
                table: "clienteProducto",
                column: "IdProductoFk");

            migrationBuilder.CreateIndex(
                name: "IX_mascota_IdEspecieFk",
                table: "mascota",
                column: "IdEspecieFk");

            migrationBuilder.CreateIndex(
                name: "IX_mascota_IdPropietarioFk",
                table: "mascota",
                column: "IdPropietarioFk");

            migrationBuilder.CreateIndex(
                name: "IX_mascota_IdRazaFk",
                table: "mascota",
                column: "IdRazaFk");

            migrationBuilder.CreateIndex(
                name: "IX_medicamento_IdLaboratorioFk",
                table: "medicamento",
                column: "IdLaboratorioFk");

            migrationBuilder.CreateIndex(
                name: "IX_movimientoMedicamento_IdMedicamentoFk",
                table: "movimientoMedicamento",
                column: "IdMedicamentoFk");

            migrationBuilder.CreateIndex(
                name: "IX_movimientoMedicamento_IdTipoMovimientoFk",
                table: "movimientoMedicamento",
                column: "IdTipoMovimientoFk");

            migrationBuilder.CreateIndex(
                name: "IX_movimientoProducto_IdProductoFk",
                table: "movimientoProducto",
                column: "IdProductoFk");

            migrationBuilder.CreateIndex(
                name: "IX_movimientoProducto_IdTipoMovimientoFk",
                table: "movimientoProducto",
                column: "IdTipoMovimientoFk");

            migrationBuilder.CreateIndex(
                name: "IX_producto_IdProveedorFk",
                table: "producto",
                column: "IdProveedorFk");

            migrationBuilder.CreateIndex(
                name: "IX_raza_IdEspecieFk",
                table: "raza",
                column: "IdEspecieFk");

            migrationBuilder.CreateIndex(
                name: "IX_refreshToken_IdUserFk",
                table: "refreshToken",
                column: "IdUserFk");

            migrationBuilder.CreateIndex(
                name: "IX_tratamientoMedicamento_IdMedicamentoFk",
                table: "tratamientoMedicamento",
                column: "IdMedicamentoFk");

            migrationBuilder.CreateIndex(
                name: "IX_usersRols_IdRolFk",
                table: "usersRols",
                column: "IdRolFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cita");

            migrationBuilder.DropTable(
                name: "clienteProducto");

            migrationBuilder.DropTable(
                name: "movimientoMedicamento");

            migrationBuilder.DropTable(
                name: "movimientoProducto");

            migrationBuilder.DropTable(
                name: "refreshToken");

            migrationBuilder.DropTable(
                name: "tratamientoMedicamento");

            migrationBuilder.DropTable(
                name: "usersRols");

            migrationBuilder.DropTable(
                name: "mascota");

            migrationBuilder.DropTable(
                name: "veterinario");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "producto");

            migrationBuilder.DropTable(
                name: "tipoMovimiento");

            migrationBuilder.DropTable(
                name: "medicamento");

            migrationBuilder.DropTable(
                name: "tratamientoMedico");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "propietario");

            migrationBuilder.DropTable(
                name: "raza");

            migrationBuilder.DropTable(
                name: "proveedor");

            migrationBuilder.DropTable(
                name: "laboratorio");

            migrationBuilder.DropTable(
                name: "especie");
        }
    }
}
