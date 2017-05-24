using System;
using System.Collections.Generic;
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
        private readonly IServicioAplicativo _servicioAplicativo;
        private readonly IServicioCliente _servicioCliente;

        public ModuloPagosController(
            IServicioTransaccion servicioTransaccion,
            IServicioAplicativo servicioAplicativo,
            IServicioCliente servicioCliente)
        {
            _servicioTransaccion = servicioTransaccion;
            _servicioAplicativo = servicioAplicativo;
            _servicioCliente = servicioCliente;
        }

        [HttpPost]
        [RouteAttribute("EnviarDatosPago")]
        public IActionResult RecibirDataAplicativo(DatosEnvioPayU data)
        {
            var aplicativoActual = _servicioAplicativo.ObtenerAplicativoPorId(data.asopagosAppId);   
            string firmaAplicativo = FuncionesEncripcion.GenerarFirmaHashSHA256($"{data.asopagosAppId}-{aplicativoActual.AplicativoApiKey}-{data.amount}-{data.currency}-{data.buyerEmail}");

            Tuple<int, List<string>> erroresValidacion = ValidarDatosRecibidos(data, firmaAplicativo);            
            if (erroresValidacion.Item1>0) return BadRequest(erroresValidacion.Item2);  

            data.referenceCode = _servicioTransaccion.GenerarCodigoReferencia(DateTime.Now);
            var datosCuentaPayU = _servicioAplicativo.ObtenerDatosCuentaPayu(data.test);
            data.ApiLogin = datosCuentaPayU.ApiLogin;            
            data.accountId = datosCuentaPayU.AccountId;   
            data.merchantId = datosCuentaPayU.MerchantId;            

            data.signature = FuncionesEncripcion.GenerarFirmaHashSHA256($"{datosCuentaPayU.ApiKey}~{datosCuentaPayU.MerchantId}~{data.referenceCode}~{data.amount}~{data.currency}");   
            
            int aplicativoId = aplicativoActual.AplicativoId;
            int clienteId = _servicioCliente.ObtenerClienteId(data);            
            int idTransaccion = _servicioTransaccion.CrearTransaccion(data,aplicativoId, clienteId);
            data.extra3 = idTransaccion.ToString();
            
            return View("ConfirmarPago", data);
        }

        private Tuple<int, List<string>> ValidarDatosRecibidos(DatosEnvioPayU data, string firmaAplicativo)
        {            
            int indice = 0;
            var listaErrores = new List<string>();
            if (data == null)
            {
                listaErrores.Add("No se recibió data");
                indice++;
            }
            if (string.IsNullOrEmpty(data.description))
            {
                listaErrores.Add("La descripción no puede estar vacía");
                indice++;
            }
            if (data.amount <= 0)
            {
                listaErrores.Add("El valor de la venta debe ser mayor a 0");
                indice++;
            }
            if (data.tax > data.amount)
            {
                listaErrores.Add("El valor del impuesto no puede ser mayor al valor de la venta");
                indice++;
            }
            if (string.IsNullOrEmpty(data.currency))
            {
                listaErrores.Add("La moneda no puede venir vacía");
                indice++;
            }
            if (string.IsNullOrEmpty(data.buyerEmail) || string.IsNullOrEmpty(data.buyerFullName))
            {
                listaErrores.Add("El nombre y correo del comprador no pueden ser vacíos");
                indice++;
            }
            if (string.IsNullOrEmpty(data.shippingAdress) || string.IsNullOrEmpty(data.shippingCity) 
                || string.IsNullOrEmpty(data.shippingCountry))
            {
                listaErrores.Add("Los datos de dirección del comprador no pueden ser vacíos (dirección, ciudad, país)");
                indice++;
            }
            if (data.asopagosAppId == 0)
            {
                listaErrores.Add("El id de la Aplicación es obligatorio");
                indice++;                
            }
            if (string.IsNullOrEmpty(data.asopagosSignature) || data.asopagosSignature != firmaAplicativo)
            {
                listaErrores.Add("Hubo un problema con la firma del formulario");
                indice++;                
            }

            return new Tuple<int, List<string>>(
                indice, listaErrores
            );
        }

        [HttpGet]
        [RouteAttribute("ResponsePagePayU")]
        public IActionResult RecibirRespuestaPayU(DatosRespuestaPayU data)
        {            
            if (_servicioTransaccion.VerificarFirmaPayU(data, _servicioAplicativo.ObtenerApiKeyCuentaPayU(true)))
            {
                _servicioTransaccion.ActualizarEstadoTransaccion(data);            
                ViewBag.EstadoTransaccion = _servicioTransaccion.ObtenerEstadoTransaccion(Int32.Parse(data.transactionState), data.lapResponseCode);
            } else {
                ViewBag.EstadoTransaccion = "Hubo un problema de verificación de datos. Código: \"Firma-SHA-no-corresponde\"";
            }
            
            return View("RespuestaPago", data);
        }    

        [HttpPost]
        [RouteAttribute("ConfirmationPagePayU")]
        public IActionResult RecibirConfirmacionPayU(DatosRespuestaPayU data)
        {
            if (_servicioTransaccion.VerificarFirmaPayU(data, _servicioAplicativo.ObtenerApiKeyCuentaPayU(true)))
            {
                _servicioTransaccion.ActualizarEstadoTransaccion(data);            
                ViewBag.EstadoTransaccion = _servicioTransaccion.ObtenerEstadoTransaccion(Int32.Parse(data.transactionState), data.lapResponseCode);
            } else {
                ViewBag.EstadoTransaccion = "Hubo un problema de verificación de datos. Código: \"Firma-SHA-no-corresponde\"";
            }

            return Ok();
        }    




    }
}