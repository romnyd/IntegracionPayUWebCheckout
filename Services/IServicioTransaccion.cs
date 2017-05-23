using System;
using AsopagosPayU.Models;

namespace AsopagosPayU.Services
{
    public interface IServicioTransaccion
    {
        string GenerarCodigoReferencia(DateTime fechaTransaccion);
    }
}