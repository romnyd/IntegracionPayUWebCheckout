using System.Collections.Generic;

namespace AsopagosPayU.Models
{
    public class Aplicativo
    {
        public int AplicativoId { get; set; }
        public string AplicativoUrl { get; set; }
        public string AplicativoApiKey { get; set; }
        public List<Transaccion> TransaccionesPorAplicativo { get; set; }
    }    
}