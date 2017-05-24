using AsopagosPayU.Models;

namespace AsopagosPayU.Services
{
    public interface IServicioAplicativo
    {
        DatosCuentaPayU ObtenerDatosCuentaPayu(bool test);
        Aplicativo ObtenerAplicativoActual(string asopagosKey);
        int ObtenerAplicativoActualId(string asopagosKey);
        string ObtenerApiKeyCuentaPayU(bool test);
        Aplicativo ObtenerAplicativoPorId(int id);
    }
}