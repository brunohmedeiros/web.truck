using System;
using Web.Truck.Data.Context;
using Web.Truck.Data.Repository;
using Web.Truck.Domain.Interfaces.Data.Repositories;
using Web.Truck.Domain.Interfaces.Data.UoW;

namespace Web.Truck.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CaminhaoContext _context;
        private bool _disposed = false;

        public UnitOfWork(CaminhaoContext context)
        {
            _context = context;
        }

        public IRepositoryGeneric<TEntity> Repository<TEntity>() where TEntity : class
        {
            return new RepositoryGeneric<TEntity, CaminhaoContext>(_context);
        }

        public bool Salvar()
        {
            _context.SaveChanges();
            return true;
        }

        ~UnitOfWork() => Dispose();

        public void Dispose()
        {
            if (!_disposed)
            {
                _context.Dispose();
            }

            GC.SuppressFinalize(this);
        }
    }
}
