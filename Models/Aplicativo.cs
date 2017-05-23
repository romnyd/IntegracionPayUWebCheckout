using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsopagosPayU.Models
{
    [Table("Aplicativos")]
    public class Aplicativo
    {
        [Key]        
        public int AplicativoId { get; set; }
        public string Nombre { get; set; }

        [MaxLengthAttribute(2)]
        public string AplicativoAbreviatura { get; set; }
        public string Descripcion { get; set; }        

        [MaxLengthAttribute(512)]
        public string AplicativoUrl { get; set; }

        [MaxLengthAttribute(64)]
        public string AplicativoApiKey { get; set; }

        
                
        public List<Transaccion> TransaccionesPorAplicativo { get; set; }
    }    
}