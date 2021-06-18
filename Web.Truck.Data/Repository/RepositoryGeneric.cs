using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Web.Truck.Domain.Interfaces.Data.Repositories;

namespace Web.Truck.Data.Repository
{
    public class RepositoryGeneric<TEntity, TDataBase> : IRepositoryGeneric<TEntity> 
        where TEntity : class
        where TDataBase : DbContext
    {
        public readonly TDataBase DataBase;
        private DbSet<TEntity> Table => DataBase.Set<TEntity>();

        public RepositoryGeneric(TDataBase dataBase)
        {
            if (dataBase is null)
            {
                throw new ArgumentNullException(nameof(dataBase));
            }

            DataBase = dataBase;
        }

        public void Create(TEntity entity)
        {
            Table.Add(entity);
        }

        public void Update(TEntity entity)
        {
            DataBase.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<TEntity> GetAll()
        {
            return Table.AsNoTracking();
        }

        public IEnumerable<TEntity> GetByQuery(Expression<Func<TEntity, bool>> @where)
        {
            return Table.Where(@where).ToList();
        }

        public IQueryable<TEntity> GetByQuery(params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = Table;
            foreach (Expression<Func<TEntity, object>> item in includes)
            {
                query = query.Include(item);
            }
            return query;
        }

        public void Delete(TEntity entity)
        {
            Table.Remove(entity);
        }
    }
}
