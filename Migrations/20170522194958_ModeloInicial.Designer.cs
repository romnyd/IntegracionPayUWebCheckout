using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AsopagosPayU.Models;

namespace AsopagosPayU.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20170522194958_ModeloInicial")]
    partial class ModeloInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("AsopagosPayU.Models.Aplicativo", b =>
                {
                    b.Property<int>("AplicativoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AplicativoApiKey")
                        .HasMaxLength(64);

                    b.Property<string>("AplicativoUrl")
                        .HasMaxLength(512);

                    b.HasKey("AplicativoId");

                    b.ToTable("Aplicativos");
                });

            modelBuilder.Entity("AsopagosPayU.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClienteDireccionPrincipal")
                        .HasMaxLength(512);

                    b.Property<string>("ClienteEmail")
                        .HasMaxLength(256);

                    b.Property<string>("ClienteNombre")
                        .HasMaxLength(128);

                    b.Property<string>("ClienteTelefono")
                        .HasMaxLength(16);

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("AsopagosPayU.Models.Transaccion", b =>
                {
                    b.Property<int>("TransaccionId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AplicativoId");

                    b.Property<string>("Ciudad")
                        .HasMaxLength(64);

                    b.Property<int>("ClienteId");

                    b.Property<string>("CodigoReferencia")
                        .HasMaxLength(64);

                    b.Property<string>("Descripcion")
                        .HasMaxLength(512);

                    b.Property<string>("EstadoTransaccion")
                        .HasMaxLength(32);

                    b.Property<string>("MedioDePago")
                        .HasMaxLength(32);

                    b.Property<string>("Moneda")
                        .HasMaxLength(4);

                    b.Property<string>("Pais")
                        .HasMaxLength(4);

                    b.Property<string>("PayUTransaccionId")
                        .HasMaxLength(64);

                    b.Property<decimal?>("PorcentajeImpuesto");

                    b.Property<decimal?>("ValorImpuesto");

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
