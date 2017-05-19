namespace AsopagosPayU.Models
{
    public class DatosRespuestaPayU
    {
        public int merchantId { get; set; }
        public string merchantName { get; set; }
        public string merchantAddress { get; set; }
        public string telephone { get; set; }
        public string merchantUrl { get; set; }
        public string transactionState { get; set; }
        public string lapTransactionState { get; set; }
        public string message { get; set; }
        public string referenceCode { get; set; }
        public string transactionId { get; set; }
        public string description { get; set; }
        public string trazabilityCode { get; set; }
        public int cus { get; set; }
        public string orderLanguage { get; set; }
        public string extra1 { get; set; }
        public string extra2 { get; set; }
        public string extra3 { get; set; }
        public int polTransactionState { get; set; }
        public string signature { get; set; }
        public int polResponseCode { get; set; }
        public string lapResponseCode { get; set; }
        public decimal risk { get; set; }
        public int polPaymentMethod { get; set; }
        public string lapPaymentMethod { get; set; }
        public int polPaymentMethodType { get; set; }
        public string lapPaymentMethodType { get; set; }
        public int installmentsNumber { get; set; }
        public decimal TX_VALUE { get; set; }
        public decimal TX_TAX { get; set; }
        public string currency { get; set; }
        public string lng { get; set; }
        public string pseCycle { get; set; }
        public string buyerEmail { get; set; }
        public string pseBank { get; set; }
        public string pseReference1 { get; set; }
        public string pseReference2 { get; set; }
        public string pseReference3 { get; set; }
        public string authorizationCode { get; set; }
        public string processingDate { get; set; }

    }
}