using eDirectory.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eDirectory.Data
{
    public class RepositoryLocatorCustomerSql
        : RepositoryLocatorBase
    {
        public override IRepository<T> GetRepository<T>()
        {
            return (IRepository<T>)new RepositoryCustomerSql();
        }
    }
}