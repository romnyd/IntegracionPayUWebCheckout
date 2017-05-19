using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AsopagosPayU.Models;

namespace AsopagosPayU.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20170519164348_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("AsopagosPayU.Models.Aplicativo", b =>
                {
                    b.Property<int>("AplicativoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AplicativoApiKey");

                    b.Property<string>("AplicativoUrl");

                    b.HasKey("AplicativoId");

                    b.ToTable("Aplicativos");
                });

            modelBuilder.Entity("AsopagosPayU.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClienteDireccionPrincipal");

                    b.Property<string>("ClienteEmail");

                    b.Property<string>("ClienteNombre");

                    b.Property<string>("ClienteTelefono");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("AsopagosPayU.Models.Transaccion", b =>
                {
                    b.Property<int>("TransaccionId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AplicativoId");

                    b.Property<string>("Ciudad");

                    b.Property<int>("ClienteId");

                    b.Property<string>("CodigoReferencia");

                    b.Property<string>("Descripcion");

                    b.Property<string>("Moneda");

                    b.Property<string>("Pais");

                    b.Property<string>("PayUTransactionId");

                    b.Property<decimal>("PorcentajeImpuesto");

                    b.Property<decimal>("ValorImpuesto");

                    b.Property<decimal>("ValorVenta");

                    b.HasKey("TransaccionId");

                    b.HasIndex("AplicativoId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Transacciones");
                });

            modelBuilder.Entity("AsopagosPayU.Models.Transaccion", b =>
                {
                    b.HasOne("AsopagosPayU.Models.Aplicativo", "Aplicativo")
                        .WithMany("TransaccionesPorAplicativo")
                        .HasForeignKey("AplicativoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AsopagosPayU.Models.Cliente", "Cliente")
                        .WithMany("TransaccionesPorCliente")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
