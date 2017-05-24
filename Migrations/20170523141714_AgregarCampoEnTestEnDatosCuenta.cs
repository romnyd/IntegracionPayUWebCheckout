using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AsopagosPayU.Migrations
{
    public partial class AgregarCampoEnTestEnDatosCuenta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "DatosCuenta",
                newName: "Id");

            migrationBuilder.AddColumn<bool>(
                name: "Test",
                table: "DatosCuenta",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DatosCuenta",
                newName: "id");

            migrationBuilder.DropColumn(
                name: "Test",
                table: "DatosCuenta");
        }
    }
}
