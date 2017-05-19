using AsopagosPayU.Infraestructura;
using AsopagosPayU.Models;
using Microsoft.AspNetCore.Mvc;

namespace AsopagosPayU.Controllers
{
    [Route("api/[controller]")]
    public class ModuloPagosController : Controller
    {
        [HttpPost]
        public IActionResult Create(DatosTransaccionPayU data)
        {
            if (data == null) return BadRequest();          
            
            data.ApiLogin = DatosCuentaPayU.ApiLogin;            
            data.accountId = DatosCuentaPayU.AccountId;         

            data.test = true;

            data.signature = FuncionesEncripcion.GenerarFirmaHashSHA256($"{DatosCuentaPayU.ApiKey}~{DatosCuentaPayU.MerchantId}~{data.referenceCode}~{data.amount}~{data.currency}");   

            return View("ConfirmarPago", data);
        }
    }
}