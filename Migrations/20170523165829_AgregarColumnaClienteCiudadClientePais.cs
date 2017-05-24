using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AsopagosPayU.Migrations
{
    public partial class AgregarColumnaClienteCiudadClientePais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClienteCiudad",
                table: "Clientes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientePais",
                table: "Clientes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClienteCiudad",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "ClientePais",
                table: "Clientes");
        }
    }
}
