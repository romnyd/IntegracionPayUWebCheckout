using AsopagosPayU.Infraestructura;
using AsopagosPayU.Models;
using Microsoft.AspNetCore.Mvc;

namespace AsopagosPayU.Controllers
{
    [Route("api/[controller]")]
    public class ModuloPagosController : Controller
    {
        [HttpPost]
        [RouteAttribute("EnviarDatosPago")]
        public IActionResult RecibirDataAplicativo(DatosTransaccionPayU data)
        {
            if (data == null) return BadRequest();          
            
            data.ApiLogin = DatosCuentaPayU.ApiLogin;            
            data.accountId = DatosCuentaPayU.AccountId;   
            data.merchantId = DatosCuentaPayU.MerchantId;                  

            data.test = true;

            data.signature = FuncionesEncripcion.GenerarFirmaHashSHA256($"{DatosCuentaPayU.ApiKey}~{DatosCuentaPayU.MerchantId}~{data.referenceCode}~{data.amount}~{data.currency}");   

            return View("ConfirmarPago", data);
        }


        [HttpGet]
        [RouteAttribute("ResponsePagePayU")]
        public IActionResult RecibirRespuestaPayU(DatosRespuestaPayU data)
        {
            var holamundo = data.TX_VALUE;

            return Ok();
        }    

        [HttpPost]
        [RouteAttribute("ConfirmationPagePayU")]
        public IActionResult RecibirConfirmacionPayU(DatosRespuestaPayU data)
        {
            var holamundo = data.TX_VALUE;

            return Ok();
        }    




    }
}