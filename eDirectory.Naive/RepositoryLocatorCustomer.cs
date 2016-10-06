using eDirectory.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eDirectory.Naive
{
    public class RepositoryLocatorCustomer : RepositoryLocatorBase
    {
        public override IRepository<T> GetRepository<T>()
        {
            return (IRepository<T>)new RepositoryCustomer();
        }
    }
}