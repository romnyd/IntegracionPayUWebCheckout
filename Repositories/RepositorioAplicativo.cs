using System;
using System.Linq;
using AsopagosPayU.Models;
using Microsoft.EntityFrameworkCore;

namespace AsopagosPayU.Repositories
{
    public class RepositorioAplicativo : IRepositorioAplicativo
    {
        private readonly Contexto _dbContext;

        public RepositorioAplicativo(Contexto context)
        {
            _dbContext = context;
            
        }

        public Aplicativo ObternerAplicativoPorNombre(string nombre)
        {
            var respuesta = _dbContext.Set<Aplicativo>()
                        .AsNoTracking()
                        .Where(x => x.AplicativoNombre == nombre)
                        .FirstOrDefault();
            return respuesta;
        }

        public DatosCuentaPayU ObtenerDatosCuentaPayU(bool test)
        {
            return _dbContext.Set<DatosCuentaPayU>()
                    .AsNoTracking()                            
                    .FirstOrDefault(x => x.Test == test);            
        }
        
        public Aplicativo ObtenerAplicativoPorApiKey(string apiKey)
        {
            return _dbContext.Set<Aplicativo>()
                    .AsNoTracking()
                    .FirstOrDefault(x => x.AplicativoApiKey == apiKey);
        }

        public int ObtenerAplicativoActualId(string apiKey)
        {
            return _dbContext.Set<Aplicativo>()
                    .AsNoTracking()
                    .Where(x => x.AplicativoApiKey == apiKey)
                    .Select(x => x.AplicativoId)
                    .FirstOrDefault();
        }

        public string ObtenerApiKeyCuentaPayU(bool test)
        {
            return _dbContext.Set<DatosCuentaPayU>()
                    .AsNoTracking()
                    .Where(x => x.Test == test)
                    .Select(x => x.ApiKey)
                    .FirstOrDefault();
        }

        public Aplicativo ObtenerAplicativoPorId(int id)
        {
            return _dbContext.Set<Aplicativo>()
                    .AsNoTracking()
                    .FirstOrDefault(x => x.AplicativoId == id);
        }
    }

}