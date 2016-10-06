using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eDirectory.Domain
{
    public interface IRepository<TEntity>
    {
        #region CRUD operations

        TEntity Save(TEntity e);
        void Update(TEntity e);
        void Remove(TEntity e);

        #region Retrievel Operations

        TEntity GetById(long id);
        IQueryable<TEntity> FindAll();

        #endregion  

        #endregion
    }
}