namespace AsopagosPayU.Models
{    
    public class Transaccion
    {
        public int TransaccionId { get; set; }
        public string PayUTransactionId { get; set; }
        public string CodigoReferencia { get; set; }
        public string Descripcion { get; set; }
        public decimal ValorVenta { get; set; }
        public decimal ValorImpuesto { get; set; }
        public decimal PorcentajeImpuesto { get; set; }
        public string Moneda { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public int AplicativoId { get; set; }
        public Aplicativo Aplicativo { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }

}