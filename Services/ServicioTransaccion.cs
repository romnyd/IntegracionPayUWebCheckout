using System;
using AsopagosPayU.Infraestructura;

namespace AsopagosPayU.Services
{
    public class ServicioTransaccion : IServicioTransaccion
    {
        public string GenerarCodigoReferencia(DateTime fechaTransaccion)
        {            
            string milisegundo = (fechaTransaccion.Millisecond%100).ToString().PadLeft(2, '0');            
            string randomString = FuncionesEncripcion.GenerarRandomString(4);
            return $"LS{milisegundo}{randomString}";
        }
    }
}

