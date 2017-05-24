namespace AsopagosPayU.Models
{
    public class DatosRespuestaAplicativo
    {
        public string transactionState { get; set; }
        public decimal amount { get; set; }
        public string buyerEmail { get; set; }
        public string extra1 { get; set; }
        public string extra2 { get; set; }                
    }
}