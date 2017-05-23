using AsopagosPayU.Models;

namespace AsopagosPayU.Repositories
{
    public interface IRepositorioAplicativo
    {
        Aplicativo ObtenerAplicativoPorId(int id);        
        Aplicativo ObternerAplicativoPorNombre(string nombre);
        
    }
}