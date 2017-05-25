using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AsopagosPayU.Migrations
{
    public partial class CreacionModeloInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aplicativos",
                columns: table => new
                {
                    AplicativoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    AplicativoAbreviatura = table.Column<string>(maxLength: 2, nullable: true),
                    AplicativoApiKey = table.Column<string>(maxLength: 64, nullable: true),
                    AplicativoNombre = table.Column<string>(nullable: true),
                    AplicativoUrl = table.Column<string>(maxLength: 512, nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aplicativos", x => x.AplicativoId);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    ClienteCiudad = table.Column<string>(maxLength: 64, nullable: true),
                    ClienteDireccionPrincipal = table.Column<string>(maxLength: 512, nullable: true),
                    ClienteEmail = table.Column<string>(maxLength: 256, nullable: true),
                    ClienteNombre = table.Column<string>(maxLength: 128, nullable: true),
                    ClientePais = table.Column<string>(maxLength: 4, nullable: true),
                    ClienteTelefono = table.Column<string>(maxLength: 16, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "DatosCuenta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    AccountId = table.Column<int>(nullable: false),
                    ApiKey = table.Column<string>(nullable: true),
                    ApiLogin = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    MerchantId = table.Column<int>(nullable: false),
                    NombreCuenta = table.Column<string>(nullable: true),
                    Test = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatosCuenta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transacciones",
                columns: table => new
                {
                    TransaccionId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    AplicativoId = table.Column<int>(nullable: false),
                    Ciudad = table.Column<string>(maxLength: 64, nullable: true),
                    ClienteId = table.Column<int>(nullable: false),
                    CodigoReferencia = table.Column<string>(maxLength: 64, nullable: true),
                    Descripcion = table.Column<string>(maxLength: 512, nullable: true),
                    EstadoTransaccion = table.Column<string>(maxLength: 32, nullable: true),
                    FechaTransaccion = table.Column<DateTime>(nullable: true),
                    MedioDePago = table.Column<string>(maxLength: 32, nullable: true),
                    Moneda = table.Column<string>(maxLength: 4, nullable: true),
                    Pais = table.Column<string>(maxLength: 4, nullable: true),
                    PayUTransaccionId = table.Column<string>(maxLength: 64, nullable: true),
                    PorcentajeImpuesto = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    ValorImpuesto = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    ValorVenta = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacciones", x => x.TransaccionId);
                    table.ForeignKey(
                        name: "FK_Transacciones_Aplicativos_AplicativoId",
                        column: x => x.AplicativoId,
                        principalTable: "Aplicativos",
                        principalColumn: "AplicativoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transacciones_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_AplicativoId",
                table: "Transacciones",
                column: "AplicativoId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_ClienteId",
                table: "Transacciones",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DatosCuenta");

            migrationBuilder.DropTable(
                name: "Transacciones");

            migrationBuilder.DropTable(
                name: "Aplicativos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
