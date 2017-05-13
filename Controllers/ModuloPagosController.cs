using AsopagosPayU.Infraestructure;
using AsopagosPayU.Models;
using Microsoft.AspNetCore.Mvc;

namespace AsopagosPayU.Controllers
{
    [Route("api/[controller]")]
    public class ModuloPagosController : Controller
    {
        [HttpPost]
        public IActionResult Create(PayUBase data)
        {
            if (data == null) return BadRequest();          

            data.merchantId = AccountData.MerchantId;
            data.ApiLogin = AccountData.ApiLogin;
            data.ApiKey = AccountData.ApiKey;
            data.accountId = AccountData.AccountId;         

            data.test = true;

            data.signature = EncryptionFunctions.GenerateHash($"{AccountData.ApiKey}~{AccountData.MerchantId}~{data.referenceCode}~{data.amount}~{data.currency}");   

            return View("ConfirmarPago", data);
        }
    }
}