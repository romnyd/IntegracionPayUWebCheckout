using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsopagosPayU.Models
{
    [Table("DatosCuenta")]
    public class DatosCuentaPayU
    {
        [Key]
        public int Id { get; set; }
        public bool Test { get; set; }
        public int MerchantId { get; set; }
        public string ApiLogin { get; set; }
        public string ApiKey { get; set; }
        public int AccountId { get; set; }
        public string Country { get; set; }
        public string NombreCuenta { get; set; }

    }
}
