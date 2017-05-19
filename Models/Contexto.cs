using Microsoft.EntityFrameworkCore;

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
}