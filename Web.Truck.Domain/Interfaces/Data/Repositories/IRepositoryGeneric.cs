using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Web.Truck.Domain.Interfaces.Data.Repositories
{
    public interface IRepositoryGeneric<TEntity> where TEntity : class
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        IQueryable<TEntity> GetAll();
        IEnumerable<TEntity> GetByQuery(Expression<Func<TEntity, bool>> @where);
        IQueryable<TEntity> GetByQuery(params Expression<Func<TEntity, object>>[] includes);
        void Delete(TEntity entity);
    }
}
