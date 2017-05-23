using System;
using AsopagosPayU.Models;
using AsopagosPayU.Repositories;

namespace AsopagosPayU.Services
{
    public class ServicioCliente : IServicioCliente
    {
        private IRepositorioCliente _repositorioCliente;

        public ServicioCliente(IRepositorioCliente repositorioCliente)
        {
            _repositorioCliente = repositorioCliente;            
        }
        public bool AgregarCliente(Cliente cliente)
        {
            return _repositorioCliente.AgregarCliente(cliente);
        }
    }
}