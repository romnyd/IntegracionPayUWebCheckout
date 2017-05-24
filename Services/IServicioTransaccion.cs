using System;
using AsopagosPayU.Models;

namespace AsopagosPayU.Services
{
    public interface IServicioTransaccion
    {
        string GenerarCodigoReferencia(DateTime fechaTransaccion);
        int CrearTransaccion(DatosEnvioPayU data, int aplicativoId, int clienteId);
        void ActualizarEstadoTransaccion(DatosRespuestaPayU data);
        string ObtenerEstadoTransaccion(int transactionState, string lapResponseCode);
        bool VerificarFirmaPayU(DatosRespuestaPayU data, string apiKey);
    }
}