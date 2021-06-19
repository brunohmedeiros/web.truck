using System;
using Web.Truck.Domain.Interfaces.Data.Repositories;

namespace Web.Truck.Domain.Interfaces.Data.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryGeneric<TEntity> Repository<TEntity>() where TEntity : class;
        bool Salvar();
    }
}
