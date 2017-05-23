using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsopagosPayU.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [MaxLengthAttribute(256)]       
        public string ClienteEmail { get; set; }

        [MaxLengthAttribute(128)] 
        public string ClienteNombre { get; set; }

        [MaxLengthAttribute(512)] 
        public string ClienteDireccionPrincipal { get; set; }

        [MaxLengthAttribute(16)] 
        public string ClienteTelefono { get; set; }
        
        public List<Transaccion> TransaccionesPorCliente { get; set; }
    }

}