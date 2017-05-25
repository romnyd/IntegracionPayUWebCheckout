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

            // Conexión a MySQL
            optionsBuilder.UseMySql("server=localhost;database=ASOPAGOSPAYU;uid=root;pwd=123456");                        
            
            // Conexión a SQL Lite
            //optionsBuilder.UseSqlite("Data Source=asopagospayu.db");        
        }

            
            
    }
}