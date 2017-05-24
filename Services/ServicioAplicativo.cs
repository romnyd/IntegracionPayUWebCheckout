using System;
using AsopagosPayU.Models;
using AsopagosPayU.Repositories;

namespace AsopagosPayU.Services
{
    public class ServicioAplicativo : IServicioAplicativo
    {
        private readonly IRepositorioAplicativo _repositorioAplicativo;

        public ServicioAplicativo(IRepositorioAplicativo repositorioAplicativo)
        {
            _repositorioAplicativo = repositorioAplicativo;
        }

        public string ObtenerApiKeyCuentaPayU(bool test)
        {
            return _repositorioAplicativo.ObtenerApiKeyCuentaPayU(test);
        }

        public Aplicativo ObtenerAplicativoActual(string asopagosKey)
        {
            return _repositorioAplicativo.ObtenerAplicativoPorApiKey(asopagosKey);
        }

        public int ObtenerAplicativoActualId(string asopagosKey)
        {
            return _repositorioAplicativo.ObtenerAplicativoActualId(asopagosKey);
        }

        public Aplicativo ObtenerAplicativoPorId(int id)
        {
            return _repositorioAplicativo.ObtenerAplicativoPorId(id);
        }

        public DatosCuentaPayU ObtenerDatosCuentaPayu(bool test)
        {
            return _repositorioAplicativo.ObtenerDatosCuentaPayU(test);
        }
        
    }
}