using System;
using AsopagosPayU.Models;

namespace AsopagosPayU.Repositories
{
    public class RepositorioCliente : IRepositorioCliente
    {
        private Contexto _dbContext;

        public RepositorioCliente(Contexto context)
        {
            _dbContext = context;
        }

        bool IRepositorioCliente.AgregarCliente(Cliente cliente)
        {
            _dbContext.Add(cliente);
            return _dbContext.SaveChanges() > 0;            
        }
    }
}