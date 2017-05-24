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
        public int AgregarCliente(Cliente cliente)
        {
            return _repositorioCliente.AgregarCliente(cliente);
        }

        /// <summary>
        /// Según los datos recibidos, crea un nuevo cliente si el email no existe o obtiene el id del cliente existente segun su email
        /// </summary>
        public int ObtenerClienteId(DatosEnvioPayU data)
        {            
            int idCliente = _repositorioCliente.ObtenerClienteIdPorEmail(data.buyerEmail);            
            if (idCliente != 0) return idCliente;
            
            int idNuevoCliente =_repositorioCliente.AgregarCliente(new Cliente{
                ClienteEmail = data.buyerEmail,
                ClienteNombre = data.buyerFullName,
                ClienteDireccionPrincipal = data.shippingAdress,
                ClienteCiudad = data.shippingCity,
                ClientePais = data.shippingCountry,
                ClienteTelefono = data.telephone                
            });
            return idNuevoCliente;
        }
    }
}