using System;
using AsopagosPayU.Infraestructura;
using AsopagosPayU.Models;
using AsopagosPayU.Services;
using Microsoft.AspNetCore.Mvc;

namespace AsopagosPayU.Controllers
{
    [Route("api/[controller]")]
    public class ModuloPagosController : Controller
    {
        private readonly IServicioTransaccion _servicioTransaccion;

        public ModuloPagosController(IServicioTransaccion servicioTransaccion)
        {
            _servicioTransaccion = servicioTransaccion;
        }


        [HttpPost]
        [RouteAttribute("EnviarDatosPago")]
        public IActionResult RecibirDataAplicativo(DatosEnvioPayU data)
        {
            if (data == null) return BadRequest();                      
            
            data.referenceCode = _servicioTransaccion.GenerarCodigoReferencia(DateTime.Now);
            data.ApiLogin = DatosCuentaPayU.ApiLogin;            
            data.accountId = DatosCuentaPayU.AccountId;   
            data.merchantId = DatosCuentaPayU.MerchantId;
            data.test = data.test;

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