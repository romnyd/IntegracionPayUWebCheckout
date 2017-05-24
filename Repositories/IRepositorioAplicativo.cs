using AsopagosPayU.Models;

namespace AsopagosPayU.Repositories
{
    public interface IRepositorioAplicativo
    {
        Aplicativo ObtenerAplicativoPorApiKey(string apiKey);        
        Aplicativo ObternerAplicativoPorNombre(string nombre);
        DatosCuentaPayU ObtenerDatosCuentaPayU(bool test);
        int ObtenerAplicativoActualId(string apiKey);
        string ObtenerApiKeyCuentaPayU(bool test);
        Aplicativo ObtenerAplicativoPorId(int id);
    }
}