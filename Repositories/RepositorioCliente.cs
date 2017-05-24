using System;
using System.Linq;
using AsopagosPayU.Models;
using Microsoft.EntityFrameworkCore;

namespace AsopagosPayU.Repositories
{
    public class RepositorioCliente : IRepositorioCliente
    {
        private Contexto _dbContext;

        public RepositorioCliente(Contexto context)
        {
            _dbContext = context;
        }

        public int AgregarCliente(Cliente cliente)
        {
            _dbContext.Add(cliente);
            _dbContext.SaveChanges();
            return cliente.ClienteId;        
        }

        public int ObtenerClienteIdPorEmail(string buyerEmail)
        {
            var cliente = _dbContext.Set<Cliente>()
                            .AsNoTracking()
                            .Where(x => x.ClienteEmail == buyerEmail)
                            .FirstOrDefault();

            return cliente != null ? cliente.ClienteId : 0;
        }
    }
}