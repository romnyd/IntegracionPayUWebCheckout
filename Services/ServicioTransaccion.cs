using System;
using AsopagosPayU.Infraestructura;
using AsopagosPayU.Models;
using AsopagosPayU.Repositories;

namespace AsopagosPayU.Services
{
    public class ServicioTransaccion : IServicioTransaccion
    {
        private readonly IRepositorioTransaccion _repositorioTransaccion;
        private readonly IRepositorioCliente _repositorioCliente;

        public ServicioTransaccion(IRepositorioTransaccion repositorioTransaccion, IRepositorioCliente repositorioCliente)
        {
            _repositorioTransaccion = repositorioTransaccion;
            _repositorioCliente = repositorioCliente;
        }

        public void ActualizarEstadoTransaccion(int idTransaccion, string medioDePago, string payUidTransaccion, string estadoTransaccion)
        {
            // int idTransaccion = Int32.Parse(data.extra3);
            // Transaccion transaccion = _repositorioTransaccion.ObtenerTransacionPorId(idTransaccion);

            // transaccion.MedioDePago = data.lapPaymentMethod;
            // transaccion.PayUTransaccionId = data.transactionId;
            // transaccion.EstadoTransaccion = data.lapResponseCode;
            
            Transaccion transaccion = _repositorioTransaccion.ObtenerTransacionPorId(idTransaccion);

            transaccion.MedioDePago = medioDePago;
            transaccion.PayUTransaccionId = payUidTransaccion;
            transaccion.EstadoTransaccion = estadoTransaccion;               

            _repositorioTransaccion.ActualizarTransaccion(transaccion);            
        }

        public int CrearTransaccion(DatosEnvioPayU data, int aplicativoId, int clienteId)
        {            

            Transaccion tr = new Transaccion {
                EstadoTransaccion = "Recibida",
                CodigoReferencia = data.referenceCode,
                Descripcion = data.description,
                ValorVenta = data.amount,
                ValorImpuesto = data.tax,
                PorcentajeImpuesto = data.taxReturnBase,
                Moneda = data.currency,
                Ciudad = data.shippingCity,
                Pais = data.shippingCountry,
                AplicativoId = aplicativoId,       
                ClienteId = clienteId      
            };

            return _repositorioTransaccion.CrearTransaccion(tr);            
        }

        public string GenerarCodigoReferencia(DateTime fechaTransaccion)
        {            
            string milisegundo = (fechaTransaccion.Millisecond%100).ToString().PadLeft(2, '0');            
            string randomString = FuncionesEncripcion.GenerarRandomString(4);
            return $"LS{milisegundo}{randomString}";
        }

        public string ObtenerEstadoTransaccion(int transactionState, string lapResponseCode)
        {
            string respuesta;
            switch(transactionState)
            {
                case 4:
                    respuesta = "APROBADA";
                break;
                case 6:
                    respuesta = "DECLINADA";
                break;
                case 5:
                    respuesta = "EXPIRADA";
                break;
                case 7:
                    respuesta = "PENDIENTE DE APROBACIÓN";
                break;
                default:
                    respuesta = "EN PROCESO";
                break;
            }

            return respuesta;
        }

        public bool VerificarFirmaPayU(DatosRespuestaPayU data, string apiKey)
        {
            var newValue = Math.Round(data.TX_VALUE, 1);
            var firma = $"{apiKey}~{data.merchantId}~{data.referenceCode}~{newValue}~{data.currency}~{data.transactionState}";
            return data.signature == FuncionesEncripcion.GenerarFirmaHashSHA256(firma);                       
        }

        public bool VerificarFirmaPayUConfirmacion(DatosConfirmacionPayU data, string apiKey)
        {
            var newValue = Math.Round(data.value, 1);
            var firma = $"{apiKey}~{data.merchant_id}~{data.reference_sale}~{newValue}~{data.currency}~{data.state_pol}";
            return data.sign == FuncionesEncripcion.GenerarFirmaHashSHA256(firma);           
        }
    }
}

