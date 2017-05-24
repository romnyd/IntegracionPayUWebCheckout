using AsopagosPayU.Models;

namespace AsopagosPayU.Repositories
{
    public interface IRepositorioTransaccion
    {
        bool AgregarTransaccion();
        int CrearTransaccion(Transaccion datosTransaccion);
        Transaccion ObtenerTransacionPorId(int idTransaccion);
        void ActualizarTransaccion(Transaccion transaccion);
    }
}