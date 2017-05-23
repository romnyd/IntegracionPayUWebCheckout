using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AsopagosPayU.Migrations
{
    public partial class ModeloInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aplicativos",
                columns: table => new
                {
                    AplicativoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    AplicativoApiKey = table.Column<string>(maxLength: 64, nullable: true),
                    AplicativoUrl = table.Column<string>(maxLength: 512, nullable: true)
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
                    ClienteDireccionPrincipal = table.Column<string>(maxLength: 512, nullable: true),
                    ClienteEmail = table.Column<string>(maxLength: 256, nullable: true),
                    ClienteNombre = table.Column<string>(maxLength: 128, nullable: true),
                    ClienteTelefono = table.Column<string>(maxLength: 16, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
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
                    MedioDePago = table.Column<string>(maxLength: 32, nullable: true),
                    Moneda = table.Column<string>(maxLength: 4, nullable: true),
                    Pais = table.Column<string>(maxLength: 4, nullable: true),
                    PayUTransaccionId = table.Column<string>(maxLength: 64, nullable: true),
                    PorcentajeImpuesto = table.Column<decimal>(nullable: true),
                    ValorImpuesto = table.Column<decimal>(nullable: true),
                    ValorVenta = table.Column<decimal>(nullable: false)
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
                name: "Transacciones");

            migrationBuilder.DropTable(
                name: "Aplicativos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
