namespace AsopagosPayU.Models
{
    public static class DatosCuentaPayU

    {
        public static int MerchantId { get; set; }
        public static string ApiLogin { get; set; }
        public static string ApiKey { get; set; }
        public static int AccountId { get; set; }
        public static string Country { get; set; }

        static DatosCuentaPayU()        
        {
            MerchantId = 508029;
            ApiLogin = "pRRXKOl8ikMmt9u";
            ApiKey = "4Vj8eK4rloUd272L48hsrarnUA";
            AccountId = 512321;
            Country = "CO";
        }

    }
}
