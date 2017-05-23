namespace AsopagosPayU.Models
{
    public class DatosEnvioPayU
    {
        public string Key { get; set; }
        public int merchantId { get; set; }
        public string referenceCode { get; set; }
        public string description { get; set; }
        public decimal amount { get; set; }
        public decimal tax { get; set; }
        public decimal taxReturnBase { get; set; }
        public string signature { get; set; }
        public long accountId { get; set; }
        public string currency { get; set; }
        public string buyerFullName { get; set; }
        public string buyerEmail { get; set; }
        public string shippingAdress { get; set; }
        public string shippingCity { get; set; }
        public string shippingCountry { get; set; }
        public string telephone { get; set; }
        public string ApiKey { get; set; }
        public string ApiLogin { get; set; }
        public bool test { get; set; }
    }
}
