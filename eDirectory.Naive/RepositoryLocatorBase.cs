using eDirectory.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eDirectory.Naive
{
    public abstract class RepositoryLocatorBase
        : IRepositoryLocator
    {
        public IQueryable<TEntity> FindAll<TEntity>()
        {
            return GetRepository<TEntity>().FindAll();
        }

        public TEntity GetById<TEntity>(long id)
        {
            return GetRepository<TEntity>().GetById(id);
        }        

        public void Remove<TEntity>(TEntity e)
        {
            GetRepository<TEntity>().Remove(e);
        }

        public TEntity Save<TEntity>(TEntity e)
        {
            return GetRepository<TEntity>().Save(e);
        }

        public void Update<TEntity>(TEntity e)
        {
            GetRepository<TEntity>().Update(e);
        }

        public abstract IRepository<T> GetRepository<T>();
    }
}