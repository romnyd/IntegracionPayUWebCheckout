using System;
using System.Linq;
using AsopagosPayU.Models;
using Microsoft.EntityFrameworkCore;

namespace AsopagosPayU.Repositories
{
    public class RepositorioTransaccion : IRepositorioTransaccion
    {
        private readonly Contexto _dbContext;

        public RepositorioTransaccion(Contexto context)
        {
            _dbContext = context;
        }

        public int CrearTransaccion(Transaccion datosTransaccion)
        {            
            _dbContext.Add(datosTransaccion);
            _dbContext.SaveChanges();
            return datosTransaccion.TransaccionId;
        }

        public bool AgregarTransaccion()
        {
            throw new NotImplementedException();
        }

        public Transaccion ObtenerTransacionPorId(int idTransaccion)
        {
            return _dbContext.Set<Transaccion>()
                    .AsNoTracking()
                    .FirstOrDefault(x => x.TransaccionId == idTransaccion);
        }

        public void ActualizarTransaccion(Transaccion transaccion)
        {
            _dbContext.Update(transaccion);
            _dbContext.SaveChanges();
        }
    }
}
