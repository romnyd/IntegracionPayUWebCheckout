using AsopagosPayU.Models;

namespace AsopagosPayU.Repositories
{
    public interface IRepositorioCliente
    {
        int AgregarCliente(Cliente cliente);
        int ObtenerClienteIdPorEmail(string buyerEmail);
    }
}