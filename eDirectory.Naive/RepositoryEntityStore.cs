using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eDirectory.Domain;

namespace eDirectory.Naive
{
    public abstract class RepositoryEntityStore<TEntity>
        : IRepository<TEntity>
    {
        protected readonly IDictionary<long, TEntity> RepositoryMap = new Dictionary<long, TEntity>();

        public IQueryable<TEntity> FindAll()
        {
            return RepositoryMap.Values.AsQueryable();
        }

        public TEntity GetById(long id)
        {
            return RepositoryMap[id];
        }

        public abstract void Remove(TEntity e);

        public abstract TEntity Save(TEntity e);

        public abstract void Update(TEntity e);
    }
}