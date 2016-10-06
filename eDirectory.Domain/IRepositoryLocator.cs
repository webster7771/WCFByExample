using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eDirectory.Domain
{
    public interface IRepositoryLocator
    {
        #region CRUD operations

        TEntity Save<TEntity>(TEntity e);
        void Update<TEntity>(TEntity e);
        void Remove<TEntity>(TEntity e);

        #region Retrievel Operations

        TEntity GetById<TEntity>(long id);
        IQueryable<TEntity> FindAll<TEntity>();

        #endregion  

        #endregion

        IRepository<T> GetRepository<T>();
    }
}