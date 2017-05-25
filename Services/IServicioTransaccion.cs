using System;
using AsopagosPayU.Models;

namespace AsopagosPayU.Services
{
    public interface IServicioTransaccion
    {
        string GenerarCodigoReferencia(DateTime fechaTransaccion);
        int CrearTransaccion(DatosEnvioPayU data, int aplicativoId, int clienteId);
        void ActualizarEstadoTransaccion(int idTransaccion, string medioDePago, string payUidTransaccion, string estadoTransaccion);
        string ObtenerEstadoTransaccion(int transactionState, string lapResponseCode);
        bool VerificarFirmaPayU(DatosRespuestaPayU data, string apiKey);
        bool VerificarFirmaPayUConfirmacion(DatosConfirmacionPayU data, string apiKey);
    }
}