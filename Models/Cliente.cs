using System.Collections.Generic;

namespace AsopagosPayU.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string ClienteEmail { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteDireccionPrincipal { get; set; }
        public string ClienteTelefono { get; set; }
        public List<Transaccion> TransaccionesPorCliente { get; set; }
    }

}