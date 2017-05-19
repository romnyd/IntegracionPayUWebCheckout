using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AsopagosPayU.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aplicativos",
                columns: table => new
                {
                    AplicativoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AplicativoApiKey = table.Column<string>(nullable: true),
                    AplicativoUrl = table.Column<string>(nullable: true)
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
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteDireccionPrincipal = table.Column<string>(nullable: true),
                    ClienteEmail = table.Column<string>(nullable: true),
                    ClienteNombre = table.Column<string>(nullable: true),
                    ClienteTelefono = table.Column<string>(nullable: true)
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
                        .Annotation("Sqlite:Autoincrement", true),
                    AplicativoId = table.Column<int>(nullable: false),
                    Ciudad = table.Column<string>(nullable: true),
                    ClienteId = table.Column<int>(nullable: false),
                    CodigoReferencia = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Moneda = table.Column<string>(nullable: true),
                    Pais = table.Column<string>(nullable: true),
                    PayUTransactionId = table.Column<string>(nullable: true),
                    PorcentajeImpuesto = table.Column<decimal>(nullable: false),
                    ValorImpuesto = table.Column<decimal>(nullable: false),
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
