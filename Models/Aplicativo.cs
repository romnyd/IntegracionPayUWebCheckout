using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AsopagosPayU.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Aplicativo> Aplicativos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Transaccion> Transacciones { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=asopagospayu.db");
        }
    }

    public class Aplicativo
    {
        public int AplicativoId { get; set; }
        public string AplicativoUrl { get; set; }
        public string AplicativoApiKey { get; set; }
        public List<Transaccion> TransaccionesPorAplicativo { get; set; }
    }

    public class Cliente
    {
        public int ClienteId { get; set; }
        public string ClienteEmail { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteDireccionPrincipal { get; set; }
        public string ClienteTelefono { get; set; }
        public List<Transaccion> TransaccionesPorCliente { get; set; }
    }

    public class Transaccion
    {
        public int TransaccionId { get; set; }
        public string PayUTransactionId { get; set; }
        public string CodigoReferencia { get; set; }
        public string Descripcion { get; set; }
        public decimal ValorVenta { get; set; }
        public decimal ValorImpuesto { get; set; }
        public decimal PorcentajeImpuesto { get; set; }
        public string Moneda { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public int AplicativoId { get; set; }
        public Aplicativo Aplicativo { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }



}