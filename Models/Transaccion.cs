using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsopagosPayU.Models
{    
    [Table("Transacciones")]
    public class Transaccion
    {
        [Key]
        public int TransaccionId { get; set; }

        [MaxLengthAttribute(32)]
        public string EstadoTransaccion { get; set; }   

        [MaxLengthAttribute(32)]
        public string MedioDePago { get; set; }     

        [MaxLengthAttribute(64)]
        public string PayUTransaccionId { get; set; }

        [MaxLengthAttribute(64)]
        public string CodigoReferencia { get; set; }

        [MaxLengthAttribute(512)]
        public string Descripcion { get; set; }

        public decimal ValorVenta { get; set; }

        public decimal? ValorImpuesto { get; set; }

        public decimal? PorcentajeImpuesto { get; set; }

        [MaxLengthAttribute(4)]
        public string Moneda { get; set; }

        [MaxLengthAttribute(64)]
        public string Ciudad { get; set; }

        [MaxLengthAttribute(4)]
        public string Pais { get; set; }

        [ForeignKeyAttribute("Aplicativo_FK")]
        public int AplicativoId { get; set; }
        public Aplicativo Aplicativo { get; set; }

        [ForeignKeyAttribute("Cliente_FK")]
        public int ClienteId { get; set; }        
        public Cliente Cliente { get; set; }
        public DateTime FechaTransaccion { get; set; }
    }

}