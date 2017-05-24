using AsopagosPayU.Models;

namespace AsopagosPayU.Services
{
    public interface IServicioCliente
    {
        int AgregarCliente(Cliente cliente);
        int ObtenerClienteId(DatosEnvioPayU data);
    }
}