using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AsopagosPayU.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Aplicativo> Aplicativos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Transaccion> Transacciones { get; set; }
        public DbSet<DatosCuentaPayU> DatosCuenta { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO traer la cadena de conexión desde appsettings.json

            // Conexión a MySQL local
            // optionsBuilder.UseMySql("server=localhost;database=ASOPAGOSPAYU;uid=root;pwd=123456");                        

            // Conexión a MySQL Producción
            optionsBuilder.UseMySql("server=www.asopagos.com;database=asopagos_legalAsop;uid=asopagos_fredyv;pwd=3ewiQm7u");                      
            
            // Conexión a SQL Lite
            // optionsBuilder.UseSqlite("Data Source=asopagospayu.db");   
            
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {            

            foreach (var property in modelBuilder.Model.GetEntityTypes() 
                .SelectMany(t => t.GetProperties()) 
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?) )) 
                { 
                    property.Relational().ColumnType = "decimal(18, 2)"; 
                } 
        }



            
            
    }
}